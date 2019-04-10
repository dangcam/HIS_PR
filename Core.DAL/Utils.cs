using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.DAL
{
    public class Utils
    {
        //<add key = "urldaotao" value="https://wsdt.baohiemxahoi.gov.vn" />
        //<add key = "urlchinh" value="https://egw.baohiemxahoi.gov.vn" />
        // Thông tin Token
        private static string url = "https://egw.baohiemxahoi.gov.vn";
        private static KQPhienLamViec phienLamViec = new KQPhienLamViec();
        //
        private static System.Globalization.CultureInfo elGR = System.Globalization.CultureInfo.CreateSpecificCulture("el-GR");
        public static Connection db = new Connection();
        public static string ToMD5(string matKhau)
        {
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(matKhau);
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static bool ThemHoatDong(string noidung, string err =null)
        {
            //return true;
            if (db == null)
            {
                db = new Connection();
            }
            return db.MyExecuteNonQuery("SpThemHoatDong",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Ma_NV", AppConfig.MaNV),
                new SqlParameter("@Ten_May", Environment.MachineName),
                new SqlParameter("@NguoiDung", Environment.UserName),
                new SqlParameter("@Ngay", DateTime.Now),
                new SqlParameter("@HoatDong", noidung));
        }
        public static string GetQuyen(string MaCN)
        {
            if (db == null)
            {
                db = new Connection();
            }
            DataTable data = db.ExcuteQuery("Select * From DanhSachQuyen,ChucNang Where Ma_NV = '" + AppConfig.MaNV +
                "' And Lop_CN = '" + MaCN + "' And DanhSachQuyen.Ma_CN = ChucNang.Ma_CN And ChucNang.TinhTrang = 1",
               CommandType.Text, null);
            if (data == null || data.Rows.Count == 0)
            {
                return "";
            }
            return data.Rows[0]["MaQuyen"].ToString();
        }
        public static bool CheckMenu(string MaCN)
        {
            if (db == null)
            {
                db = new Connection();
            }
            DataTable data = db.ExcuteQuery("Select * From DanhSachQuyen Where Ma_NV = '" + AppConfig.MaNV + "' And Ma_CN = '" + MaCN + "'",
                CommandType.Text, null);
            if (data == null || data.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static string VietHoa(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            string result = "";

            //lấy danh sách các từ  

            string[] words = s.Split(' ');

            foreach (string word in words)
            {
                // từ nào là các khoảng trắng thừa thì bỏ  
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1) + " ";
                    else
                        result += word.ToUpper() + " ";
                }

            }
            return result.Trim();
        }
        public static int LastDay(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }
        public static bool ToBoolean(object value, bool defaultvalue = false)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return defaultvalue;
            }
        }
        public static double ToDouble(string value, double defaultvalue = 0)
        {
            try
            {
                value = value.Replace(",", "");
                return Convert.ToDouble(value);
            }
            catch
            {
                return defaultvalue;
            }
        }
 
        public static decimal ToDecimal(string value, decimal defaultvalue = 0)
        {
            try
            {
                value = value.Replace(",", "");
                return Convert.ToDecimal(value);
            }
            catch
            {
                return defaultvalue;
            }
        }
        public static decimal ToDecimal(object value, decimal defaultvalue = 0)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return defaultvalue;
            }
        }
        public static float ToFloat(string value, float defaultvalue = 0)
        {
            try
            {
                return float.Parse(value);
            }
            catch
            {
                return defaultvalue;
            }
        }
        public static string ToString(string value, string defaultvalue = null, string format = "0,0")
        {
            try
            {
                decimal t = ToDecimal(value);
                if (defaultvalue == null && t == 0)
                {
                    return null;
                }
                return t.ToString(format, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                return defaultvalue;
            }
        }
        public static string ToString(decimal value, decimal defaultvalue = 0)
        {
            try
            {
                return value.ToString("0,0", elGR);
            }
            catch
            {
                return defaultvalue.ToString();
            }
        }
        public static string ToString(object value, string defaultvalue = null)
        {
            try
            {
                return Convert.ToString(value);
            }
            catch
            {
                return defaultvalue;
            }
        }
        public static string StringToString(string value, string defaultvalue = null)
        {
            return string.IsNullOrEmpty(value) ? defaultvalue : value;
        }
        public static string ToLowerFirstChar(string input)
        {
            string newString = input;
            if (!String.IsNullOrEmpty(newString) && Char.IsUpper(newString[0]))
                newString = Char.ToLower(newString[0]) + newString.Substring(1);
            return newString;
        }
        public static string ToString(DateTime value, string format)
        {
            return value.ToString(format);
        }
        public static int ToInt(object value, int defaultvalue = 0)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultvalue;
            }

        }
        public static int ToInt(string value, int defaultvalue = 0)
        {
            try
            {
                value = value.Replace(",", "");
                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultvalue;
            }
        }
        public static byte[] XmlToByte(XmlDocument doc)
        {
            byte[] result;
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                doc.Save(memoryStream);
                result = memoryStream.ToArray();
            }
            return result;
        }
        public static string ChuyenSo(string number)
        {
            string[] dv = { "", "mươi", "trăm", "nghìn", "triệu", "tỉ" };
            string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string doc;
            int i, j, k, n, len, found, ddv, rd;

            len = number.Length;
            number += "ss";
            doc = "";
            found = 0;
            ddv = 0;
            rd = 0;

            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }
                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3)
                                    doc += cs[0] + " ";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0')
                                        doc += "lẻ ";
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3)
                                    doc += cs[1] + " ";
                                if (n - j == 2)
                                {
                                    doc += "mười ";
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0)
                                        k = 0;
                                    else
                                        k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        doc += "mốt ";
                                    else
                                        doc += cs[1] + " ";
                                }
                                break;
                            case '5':
                                if (i + j == len - 1)
                                    doc += "lăm ";
                                else
                                    doc += cs[5] + " ";
                                break;
                            default:
                                doc += cs[(int)number[i + j] - 48] + " ";
                                break;
                        }

                        //Doc don vi nho
                        if (ddv == 1)
                        {
                            doc += dv[n - j - 1] + " ";
                        }
                    }
                }

                //Doc don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                doc += "tỉ ";
                        rd = 0;
                    }
                    else
                        if (found != 0)
                        doc += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
                }

                i += n;
            }

            if (len == 1)
                if (number[0] == '0' || number[0] == '5')
                    return cs[(int)number[0] - 48];

            return doc + "đồng";
        }
        public static string VietHoaTuDong(string value)
        {
            value = value.Replace("  ", " ");
            return System.Globalization.CultureInfo.
                    CurrentCulture.TextInfo.ToTitleCase(value);
        }
        public static string HexToText(string hex)
        {
            int NumberChars = hex.Length / 2;
            byte[] bytes = new byte[NumberChars];
            using (var sr = new StringReader(hex))
            {
                for (int i = 0; i < NumberChars; i++)
                    try
                    {
                        bytes[i] =
                          Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
                    }
                    catch { }
            }
            string utf8result = System.Text.Encoding.UTF8.GetString(bytes);
            return utf8result;
        }
        public static async Task<ThongTinThe> KiemTraThongTuyen(string maThe, string hoTen, string ngaySinh)
        {
            ThongTinThe thongtin = new ThongTinThe();
            thongtin.MaThe = maThe;
            thongtin.HoTen = hoTen;
            thongtin.NgaySinh = ngaySinh;
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("MaThe",thongtin.MaThe),
                new KeyValuePair<string, string>("HoTen",thongtin.HoTen),
                new KeyValuePair<string, string>("NgaySinh",thongtin.NgaySinh)
            };
            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = await client.PostAsync("https://gdbhyt.baohiemxahoi.gov.vn/ThongTuyenLSKCB/CheckMaThe", q))
                    {

                        if (response.IsSuccessStatusCode)
                        {

                            using (HttpContent content = response.Content)
                            {
                                //MessageBox.Show (content.Headers.ToString ());
                                string mycontent = await content.ReadAsStringAsync();
                                int iMessage = mycontent.IndexOf("message");
                                int iErro = mycontent.IndexOf("erro");
                                int iCode = mycontent.IndexOf("code");
                                string code = mycontent.Substring(iCode + 4, iErro - (iCode + 4));
                                code = code.Replace("\"", "").Replace(":", "").Replace(",", "");
                                string message = mycontent.Substring(iMessage + 7);
                                StringBuilder sMessage = new StringBuilder(message);
                                sMessage = sMessage.Replace("\"", "").Replace("}", "").Replace("\\u003cb", "").Replace("\\u003c", "")
                                    .Replace("\\u0027", "").Replace("style=", "").Replace("color:", "").Replace("#0070C0", "").Replace("\\u003e", "")
                                    .Replace("/b", "");
                                sMessage = sMessage.Replace("font-family:TNKeyUni-Arial", "");
                                thongtin.Code = code;
                                switch (code)
                                {
                                    case "1":
                                        GanThongTin(ref thongtin, sMessage.ToString());
                                        break;
                                    case "false":
                                        thongtin.ThongBao = "Không có thông tin!";
                                        break;
                                    default:
                                        thongtin.ThongBao = sMessage.ToString();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            thongtin.ThongBao = Library.KetNoiCong + response.RequestMessage;
                        }
                    }
                }
                catch
                {
                    thongtin.ThongBao = Library.KetNoiInternet;
                }
            }
            return thongtin;
        }
        private static void GanThongTin(ref ThongTinThe thongtinthe, string mess)
        {
            string[] mg = mess.Split('!');
            string thongtin = mg[1];
            try
            {
                string[] tmp = thongtin.Split(',');

                string hoTen = tmp[0].Trim().Split(':')[1].Trim();

                thongtinthe.HoTen = hoTen;

                string ngaySinh = tmp[1].Trim().Split(':')[1].Trim();
                thongtinthe.NgaySinh = ngaySinh;
                string gioiTinh = tmp[2].Trim().Split(':')[1].Trim();
                if (gioiTinh == "Nam")
                {
                    thongtinthe.GioiTinh = 0;
                }
                else
                {
                    thongtinthe.GioiTinh = 1;
                }

            }
            catch { }
            string thongtin2 = mg[2].Replace("(", "").Replace(")", "").Replace(".", "");
            try
            {
                string[] tmp = thongtin2.Split(';');
                string diaChi = tmp[0].Split(':')[1].TrimStart().TrimEnd().Replace("\\u0027", "'");
                thongtinthe.DiaChi = diaChi;
                string noiDKKCB = tmp[1].Split(':')[1].TrimStart().TrimEnd();
                thongtinthe.MaCoSoDKKCB = noiDKKCB;
                string hanThe = tmp[2].Split(':')[1].Trim();
                thongtinthe.TheTu = hanThe.Split('-')[0].Trim().Substring(0, 10);

                thongtinthe.TheDen = hanThe.Split('-')[1].Trim().Substring(0, 10);
                
                thongtinthe.Du5Nam = tmp[3].Split(':')[1].Trim().Substring(0,10);
            }
            catch
            {
                thongtinthe.ThongBao = Library.GanThongTinThe;
            }
        }
        public static DateTime ToDateTime(string value, string format)
        {
            try
            {
                return DateTime.ParseExact(value, format, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public static DateTime ToDateTime(string value)
        {
            //try
            //{
            //    return DateTime.Parse(value);
            //}
            //catch
            //{
            //    return DateTime.Now;
            //}
            return ToDateTime(value, DateTime.Now);
        }
        public static DateTime ToDateTime(string value, DateTime dateTime)
        {
            try
            {
                return DateTime.Parse(value);
            }
            catch
            {
                return dateTime;
            }
        }
        private static async Task<string> GetToken()
        {
            IEnumerable<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username",AppConfig.UserLoginBHYT),
                new KeyValuePair<string, string>("password",Utils.ToMD5(AppConfig.PassWordBHYT))
            };
            HttpContent user = new FormUrlEncodedContent(values);
            // lấy phiên làm việc
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    if (phienLamViec == null ||
                        phienLamViec.APIKey.expires_in < DateTime.Now)
                    {
                        using (HttpResponseMessage response = await client.PostAsync("api/token/take", user))
                         {
                             if (response.IsSuccessStatusCode)
                             {
                                 using (HttpContent content = response.Content)
                                 {
                                     //MessageBox.Show (content.Headers.ToString ());
                                     phienLamViec = await content.ReadAsAsync<KQPhienLamViec>();
                                     //mycontent = mycontent.Replace("\"", "").Replace("{", "").Replace("}", "");
                                     //string[] kq = mycontent.Split(',');
                                     //string maKetQua = mycontent.maKetQua; //kq[0].Split(':')[1];
                                     if (phienLamViec.maKetQua.Equals("200"))
                                     {
                                         //Token = mycontent.APIKey.access_token; //kq[1].Split(':')[2];
                                         //Id_Token = mycontent.APIKey.id_token;// kq[2].Split(':')[1];
                                         //Expires_In = mycontent.APIKey.expires_in.AddHours(7);
                                         // Utils.ToDateTime(kq[5].Replace("expires_in:", ""));
                                         phienLamViec.APIKey.expires_in = phienLamViec.APIKey.expires_in.AddHours(7);
                                         return null;
                                     }
                                     else if(phienLamViec.maKetQua.Equals("401"))
                                     {
                                         return  "401 - sai tài khoản hoặc mật khẩu";
                                     }
                                     else if(phienLamViec.maKetQua.Equals("402"))
                                     {
                                         return "402 - tài khoản và mã cơ sở khám chữa bệnh không trùng khớp";
                                     }
                                     else
                                     {
                                         return "Lỗi kết nối,vui lòng kiểm tra lại đường truyền mạng !";
                                     }
                                 }
                             }
                             else 
                             {
                                 return Library.KetNoiCong + response.RequestMessage;
                             }
                         }
                    }
                    return null;
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public static async Task<ThongTinLichSu> LichSuKhamChuaBenhBHYT(ThongTinThe thongTinThe)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("maThe",thongTinThe.MaThe),
                new KeyValuePair<string, string>("hoTen",thongTinThe.HoTen),
                new KeyValuePair<string, string>("ngaySinh",thongTinThe.NgaySinh),
                new KeyValuePair<string, string>("gioiTinh",(thongTinThe.GioiTinh+1)+""),
                new KeyValuePair<string, string>("maCSKCB",thongTinThe.MaCoSoDKKCB),
                new KeyValuePair<string, string>("ngayBD",thongTinThe.TheTu),
                new KeyValuePair<string, string>("ngayKT",thongTinThe.TheDen)
            };        
            HttpContent quer = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                ThongTinLichSu thongTinLichSu = new ThongTinLichSu();
                try
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    // lấy phiên làm việc
                    string err = await GetToken();
                    if(!string.IsNullOrEmpty(err))
                    {
                        thongTinLichSu.maKetQua = "false";
                        thongTinLichSu.thongBao = err;
                        return thongTinLichSu;
                    }
                    // lấy lịch sử KCB
                    string data = string.Format("token={0}&id_token={1}&username={2}&password={3}",phienLamViec.APIKey.access_token
                        , phienLamViec.APIKey.id_token, AppConfig.UserLoginBHYT, Utils.ToMD5(AppConfig.PassWordBHYT));
                    using (HttpResponseMessage response = await client.PostAsync("api/egw/KQNhanLichSuKCB595?" + data, quer))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                //string mycontent = await content.ReadAsStringAsync();
                                //mycontent = mycontent.Replace("\"", "");
                                //string ketqua = mycontent.Substring(0, mycontent.IndexOf("dsLichSuKCB"));
                                //string danhsach = mycontent.Substring(mycontent.IndexOf("dsLichSuKCB") + 11);

                                //thongTinThe.Code = ketqua.Split(',')[0].Split(':')[1]; ;
                                //thongTinThe.ThongBao = danhsach;
                                //return thongTinThe;
                                thongTinLichSu = await content.ReadAsAsync<ThongTinLichSu>();
                                return thongTinLichSu;
                            }
                        }
                        else
                        {
                            thongTinLichSu.thongBao = Library.KetNoiCong + response.RequestMessage;
                            thongTinLichSu.maKetQua = "false";
                            return thongTinLichSu;
                        }
                    }
                }
                catch(Exception e)
                {
                    thongTinLichSu.thongBao = e.Message;
                    thongTinLichSu.maKetQua = "false";
                    return thongTinLichSu;
                }
            }
        }
        public static async Task<KQNhanLichSuKCBBS> NhanLichSuKCBBS(ApiTheBHYT2018 thongTinThe)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("maThe",thongTinThe.maThe),
                new KeyValuePair<string, string>("hoTen",thongTinThe.hoTen),
                new KeyValuePair<string, string>("ngaySinh",thongTinThe.ngaySinh)
            };
            HttpContent quer = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                KQNhanLichSuKCBBS thongTinLichSu = new KQNhanLichSuKCBBS();
                try
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    // lấy phiên làm việc
                    string err = await GetToken();
                    if (!string.IsNullOrEmpty(err))
                    {
                        thongTinLichSu.maKetQua = "false";
                        thongTinLichSu.ghiChu = err;
                        return thongTinLichSu;
                    }
                    // lấy lịch sử KCB
                    string data = string.Format("token={0}&id_token={1}&username={2}&password={3}", phienLamViec.APIKey.access_token
                        , phienLamViec.APIKey.id_token, AppConfig.UserLoginBHYT, Utils.ToMD5(AppConfig.PassWordBHYT));
                    using (HttpResponseMessage response = await client.PostAsync("api/egw/NhanLichSuKCB2018?" + data, quer))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                thongTinLichSu = await content.ReadAsAsync<KQNhanLichSuKCBBS>();
                                return thongTinLichSu;
                            }
                        }
                        else
                        {
                            thongTinLichSu.ghiChu = Library.KetNoiCong + response.RequestMessage;
                            thongTinLichSu.maKetQua = "false";
                            return thongTinLichSu;
                        }
                    }
                }
                catch (Exception e)
                {
                    thongTinLichSu.ghiChu = e.Message;
                    thongTinLichSu.maKetQua = "false";
                    return thongTinLichSu;
                }
            }
        }
        public static async Task<KQLichSuKCB> NhanLichSuKCBBS2019(ApiTheBHYT2018 thongTinThe)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("maThe",thongTinThe.maThe),
                new KeyValuePair<string, string>("hoTen",thongTinThe.hoTen),
                new KeyValuePair<string, string>("ngaySinh",thongTinThe.ngaySinh)
            };
            HttpContent quer = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                KQLichSuKCB thongTinLichSu = new KQLichSuKCB();
                try
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    // lấy phiên làm việc
                    string err = await GetToken();
                    if (!string.IsNullOrEmpty(err))
                    {
                        thongTinLichSu.maKetQua = "false";
                        thongTinLichSu.ghiChu = err;
                        return thongTinLichSu;
                    }
                    // lấy lịch sử KCB
                    string data = string.Format("token={0}&id_token={1}&username={2}&password={3}", phienLamViec.APIKey.access_token
                        , phienLamViec.APIKey.id_token, AppConfig.UserLoginBHYT, Utils.ToMD5(AppConfig.PassWordBHYT));
                    using (HttpResponseMessage response = await client.PostAsync("api/egw/KQNhanLichSuKCB2019?" + data, quer))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            //using (HttpContent content = response.Content)
                            //{
                            //    thongTinLichSu = await content.ReadAsAsync<KQLichSuKCB>();
                            //    return thongTinLichSu;
                            //}
                            string result = response.Content.ReadAsStringAsync().Result;
                            thongTinLichSu = (KQLichSuKCB)JsonConvert.DeserializeObject<KQLichSuKCB>(result);
                            return thongTinLichSu;
                        }
                        else
                        {
                            thongTinLichSu.ghiChu = Library.KetNoiCong + response.RequestMessage;
                            thongTinLichSu.maKetQua = "false";
                            return thongTinLichSu;
                        }
                    }
                }
                catch (Exception e)
                {
                    thongTinLichSu.ghiChu = e.Message;
                    thongTinLichSu.maKetQua = "false";
                    return thongTinLichSu;
                }
            }
        }
        public static async Task<KQGuiHoSo> GuiHoSo4210(byte[] fileHS)
        {
            KQGuiHoSo kqGuiHoSo = new KQGuiHoSo();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.MaxResponseContentBufferSize = 2000005000L;
                    string err = await GetToken();
                    if (!string.IsNullOrEmpty(err))
                    {
                        kqGuiHoSo.maKetQua = "false_getToken";
                        kqGuiHoSo.maGiaoDich = err;
                        return kqGuiHoSo;
                    }
                    // gửi hồ sơ 4210
                    string data = string.Format("token={0}&id_token={1}&username={2}&password={3}&loaiHoSo={4}&maTinh={5}&maCSKCB={6}",
                        phienLamViec.APIKey.access_token, phienLamViec.APIKey.id_token, AppConfig.UserLoginBHYT,
                        Utils.ToMD5(AppConfig.PassWordBHYT),3, AppConfig.CoSoKCB.Substring(0,2),"70013");
                    using (HttpResponseMessage response = await client.PostAsJsonAsync("api/egw/guiHoSoGiamDinh4210?" + data, fileHS))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                kqGuiHoSo = await content.ReadAsAsync<KQGuiHoSo>();
                                return kqGuiHoSo;
                            }
                        }
                        else
                        {
                            kqGuiHoSo.maGiaoDich = Library.KetNoiCong + "\n" + response.RequestMessage;
                            kqGuiHoSo.maKetQua = "false_status";
                        }
                    }
                }
                catch (Exception ex)
                {
                    kqGuiHoSo.maGiaoDich = ex.Message;
                    kqGuiHoSo.maKetQua = "false_ex";
                }
            }
            return kqGuiHoSo;
        }
        public static async Task<LichSuKCBChiTiet> LayChiTietHoSo(string maHoSo)
        {
            LichSuKCBChiTiet lichSuKCBChiTiet = new LichSuKCBChiTiet();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    string err = await GetToken();
                    if (!string.IsNullOrEmpty(err))
                    {
                        lichSuKCBChiTiet.maKetQua = "false";
                        lichSuKCBChiTiet.ThongBao = err;
                        return lichSuKCBChiTiet;
                    }
                    // lấy lịch sử KCB
                    string data = string.Format("token={0}&id_token={1}&username={2}&password={3}&maHoSo={4}",
                        phienLamViec.APIKey.access_token, phienLamViec.APIKey.id_token, AppConfig.UserLoginBHYT, 
                        Utils.ToMD5(AppConfig.PassWordBHYT), maHoSo);
                    using (HttpResponseMessage response = await client.PostAsync("api/egw/nhanHoSoKCBChiTiet?" + data, null))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                //string mycontent = await content.ReadAsStringAsync();
                                lichSuKCBChiTiet = await content.ReadAsAsync<LichSuKCBChiTiet>();
                                //string ketqua = mycontent.Split(',')[0].Split(':')[1].Replace("\"", "");
                                //switch (ketqua)
                                //{
                                //    case "200":
                                //        try
                                //        {
                                //            string xml2 = "", xml3 = "";
                                //            if (mycontent.IndexOf("Xml2") > 0 && mycontent.IndexOf("Xml2\":[]") < 0)
                                //            {
                                //                xml2 = mycontent.Substring(mycontent.IndexOf("Xml2"), mycontent.IndexOf("}]") - mycontent.IndexOf("Xml2") + 1);
                                //                xml2 = xml2.Replace("Xml2\":[", "");
                                //                mycontent = mycontent.Substring(mycontent.IndexOf("}]") + 2);
                                //            }
                                //            if (mycontent.IndexOf("Xml3") > 0 && mycontent.IndexOf("Xml3\":[]") < 0)
                                //            {
                                //                xml3 = mycontent.Substring(mycontent.IndexOf("Xml3"), mycontent.IndexOf("]}") - mycontent.IndexOf("Xml3") + 1);
                                //                xml3 = xml3.Replace("Xml3\":[", "");
                                //            }
                                //            thongTinThe.Code = ketqua;
                                //            thongTinThe.XML2 = xml2;
                                //            thongTinThe.XML3 = xml3;
                                //        }
                                //        catch {
                                //             thongTinThe.Code = "false";
                                //            thongTinThe.ThongBao = "Lỗi dữ liệu XML2,XML3.";
                                //        }
                                //        break;
                                //    default:
                                //        thongTinThe.ThongBao = "Lỗi không được xác thực.\n" + "Lỗi - " + ketqua;
                                //        thongTinThe.Code = "false";
                                //        break;
                                //}
                            }
                        }
                        else
                        {
                            lichSuKCBChiTiet.ThongBao = Library.KetNoiCong +"\n"+ response.RequestMessage;
                            lichSuKCBChiTiet.maKetQua = "false_ketnoi";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lichSuKCBChiTiet.ThongBao = ex.Message;
                    lichSuKCBChiTiet.maKetQua = "false_ex";
                }
            }
            return lichSuKCBChiTiet;
        }
    }
}
