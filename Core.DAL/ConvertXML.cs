using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.DAL
{
    public class ConvertXML
    {
        private static string FixMaBenh(string mabenh)
        {
            mabenh = mabenh.Replace(" ", "");
            try
            {
                if(mabenh.LastIndexOf(";") == mabenh.Length - 1)
                {
                    mabenh = mabenh.Remove(mabenh.LastIndexOf(";"), 1);
                }
            }
            catch { }
            return mabenh;
        }
        public static XmlDocument XML1_4210(DataRow dataRow)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement tonghop = doc.CreateElement("TONG_HOP");
            doc.AppendChild(tonghop);

            XmlElement element = doc.CreateElement("MA_LK");
            element.AppendChild(doc.CreateTextNode(dataRow["MaLK"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("STT");
            element.AppendChild(doc.CreateTextNode(dataRow["STT"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_BN");
            element.AppendChild(doc.CreateTextNode(dataRow["MaBN"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("HO_TEN");
            element.AppendChild(doc.CreateCDataSection(dataRow["HoTen"].ToString()));
            tonghop.AppendChild(element);

            DateTime ngaysinh = dataRow["NgaySinh"].ToString().Length > 4 ?
                Utils.ToDateTime(dataRow["NgaySinh"].ToString(), "dd/MM/yyyy") : 
                Utils.ToDateTime(dataRow["NgaySinh"].ToString(), "yyyy");

            element = doc.CreateElement("NGAY_SINH");
            element.AppendChild(doc.CreateTextNode(ngaysinh.ToString("yyyyMMdd")));
            tonghop.AppendChild(element);

            element = doc.CreateElement("GIOI_TINH");
            element.AppendChild(doc.CreateTextNode((Utils.ToInt(dataRow["GioiTinh"]) + 1).ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("DIA_CHI");
            element.AppendChild(doc.CreateCDataSection(dataRow["DiaChi"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_THE");
            element.AppendChild(doc.CreateTextNode(dataRow["MaThe"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_DKBD");
            element.AppendChild(doc.CreateTextNode(dataRow["MaDKBD"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("GT_THE_TU");
            element.AppendChild(doc.CreateTextNode(Utils.ToDateTime(dataRow["TheTu"].ToString()).ToString("yyyyMMdd")));
            tonghop.AppendChild(element);

            element = doc.CreateElement("GT_THE_DEN");
            element.AppendChild(doc.CreateTextNode(Utils.ToDateTime(dataRow["TheDen"].ToString()).ToString("yyyyMMdd")));
            tonghop.AppendChild(element);

            string mienCungCT = dataRow["MienCungCT"].ToString().Length > 0 ?
                Utils.ToDateTime(dataRow["MienCungCT"].ToString()).ToString("yyyyMMdd") : null;
            element = doc.CreateElement("MIEN_CUNG_CT");
            element.AppendChild(doc.CreateTextNode(mienCungCT));
            tonghop.AppendChild(element);

            element = doc.CreateElement("TEN_BENH");
            element.AppendChild(doc.CreateCDataSection(dataRow["TenBenh"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_BENH");
            element.AppendChild(doc.CreateTextNode(FixMaBenh(dataRow["MaBenh"].ToString())));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_BENHKHAC");
            element.AppendChild(doc.CreateTextNode(FixMaBenh(dataRow["MaBenhKhac"].ToString())));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_LYDO_VVIEN");
            element.AppendChild(doc.CreateTextNode(dataRow["MaLyDoVaoVien"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_NOI_CHUYEN");
            element.AppendChild(doc.CreateTextNode(dataRow["MaNoiChuyenDen"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_TAI_NAN");
            element.AppendChild(doc.CreateTextNode(dataRow["MaTaiNan"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("NGAY_VAO");
            element.AppendChild(doc.CreateTextNode(Utils.ToDateTime(dataRow["NgayVao"].ToString()).ToString("yyyyMMddHHmm")));
            tonghop.AppendChild(element);

            element = doc.CreateElement("NGAY_RA");
            element.AppendChild(doc.CreateTextNode(Utils.ToDateTime(dataRow["NgayRa"].ToString()).ToString("yyyyMMddHHmm")));
            tonghop.AppendChild(element);

            element = doc.CreateElement("SO_NGAY_DTRI");
            element.AppendChild(doc.CreateTextNode(dataRow["SoNgayDieuTri"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("KET_QUA_DTRI");
            element.AppendChild(doc.CreateTextNode((Utils.ToInt(dataRow["KetQuaDieuTri"])).ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("TINH_TRANG_RV");
            element.AppendChild(doc.CreateTextNode((Utils.ToInt(dataRow["TinhTrangRaVien"])).ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("NGAY_TTOAN");
            element.AppendChild(doc.CreateTextNode(Utils.ToDateTime(dataRow["NgayThanhToan"].ToString()).ToString("yyyyMMddHHmm")));
            tonghop.AppendChild(element);

            element = doc.CreateElement("T_THUOC");
            element.AppendChild(doc.CreateTextNode(dataRow["TienThuoc"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("T_VTYT");
            element.AppendChild(doc.CreateTextNode(dataRow["TienVTYT"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("T_TONGCHI");
            element.AppendChild(doc.CreateTextNode(dataRow["TongChi"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("T_BNTT");
            element.AppendChild(doc.CreateTextNode(dataRow["TienBNTT"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("T_BNCCT");
            element.AppendChild(doc.CreateTextNode(dataRow["TienBNCCT"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("T_BHTT");
            element.AppendChild(doc.CreateTextNode(dataRow["TienBHTT"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("T_NGUONKHAC");
            element.AppendChild(doc.CreateTextNode(dataRow["TienNguonKhac"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("T_NGOAIDS");
            element.AppendChild(doc.CreateTextNode(dataRow["TienNgoaiDS"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("NAM_QT");
            element.AppendChild(doc.CreateTextNode(dataRow["NamQT"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("THANG_QT");
            element.AppendChild(doc.CreateTextNode(dataRow["ThangQT"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_LOAI_KCB");
            element.AppendChild(doc.CreateTextNode(dataRow["MaLoaiKCB"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_KHOA");
            element.AppendChild(doc.CreateTextNode((dataRow["MaKhoa"] + "_").Split('_')[0]));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_CSKCB");
            element.AppendChild(doc.CreateTextNode("70013"));//dataRow["MaCoSoKCB"].ToString())
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_KHUVUC");
            element.AppendChild(doc.CreateTextNode(dataRow["MaKhuVuc"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("MA_PTTT_QT");
            element.AppendChild(doc.CreateTextNode(dataRow["MaPTTTTQT"].ToString()));
            tonghop.AppendChild(element);

            element = doc.CreateElement("CAN_NANG");
            element.AppendChild(doc.CreateTextNode(dataRow["CanNang"].ToString()));
            tonghop.AppendChild(element);
            //
            return doc;
        }


        public static XmlDocument XML2_4210(DataTable dataTable, string MaBenh)
        {
            if(dataTable==null || dataTable.Rows.Count==0)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement danhsach = doc.CreateElement("DSACH_CHI_TIET_THUOC");
            doc.AppendChild(danhsach);
            foreach (DataRow dr in dataTable.Rows)
            {
                XmlElement chitiet = doc.CreateElement("CHI_TIET_THUOC");
                danhsach.AppendChild(chitiet);

                XmlElement element = doc.CreateElement("MA_LK");
                element.AppendChild(doc.CreateTextNode(dr["MaLK"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("STT");
                element.AppendChild(doc.CreateTextNode(dr["STT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_THUOC");
                element.AppendChild(doc.CreateTextNode(dr["MaThuoc"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_NHOM");
                element.AppendChild(doc.CreateTextNode(dr["MaNhom"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("TEN_THUOC");
                element.AppendChild(doc.CreateCDataSection(dr["TenThuoc"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("DON_VI_TINH");
                element.AppendChild(doc.CreateTextNode(dr["DonViTinh"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("HAM_LUONG");
                element.AppendChild(doc.CreateCDataSection(dr["HamLuong"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("DUONG_DUNG");
                element.AppendChild(doc.CreateTextNode(dr["MaDuongDung"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("LIEU_DUNG");
                element.AppendChild(doc.CreateCDataSection(dr["LieuDung"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("SO_DANG_KY");
                element.AppendChild(doc.CreateTextNode(dr["SoDK"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("TT_THAU");
                element.AppendChild(doc.CreateTextNode(dr["TTinThau"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("PHAM_VI");
                element.AppendChild(doc.CreateTextNode(dr["PhamVi"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("SO_LUONG");
                element.AppendChild(doc.CreateTextNode(dr["SoLuong"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("DON_GIA");
                element.AppendChild(doc.CreateTextNode(dr["DonGia"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("TYLE_TT");
                element.AppendChild(doc.CreateTextNode(dr["TyLe"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("THANH_TIEN");
                element.AppendChild(doc.CreateTextNode(dr["ThanhTien"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MUC_HUONG");
                element.AppendChild(doc.CreateTextNode(dr["MucHuong"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_NGUONKHAC");
                element.AppendChild(doc.CreateTextNode(dr["TienNguonKhac"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_BNTT");
                element.AppendChild(doc.CreateTextNode(dr["TienBNTT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_BHTT");
                element.AppendChild(doc.CreateTextNode(dr["TienBHTT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_BNCCT");
                element.AppendChild(doc.CreateTextNode(dr["TienBNCCT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_NGOAIDS");
                element.AppendChild(doc.CreateTextNode(dr["TienNgoaiDS"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_KHOA");
                element.AppendChild(doc.CreateTextNode((dr["MaKhoa"] + "_").Split('_')[0]));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_BAC_SI");
                element.AppendChild(doc.CreateTextNode(dr["MaBacSi"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_BENH");
                element.AppendChild(doc.CreateTextNode(FixMaBenh(MaBenh)));
                chitiet.AppendChild(element);

                element = doc.CreateElement("NGAY_YL");
                element.AppendChild(doc.CreateTextNode(Utils.ToDateTime(dr["NgayYLenh"].ToString()).ToString("yyyyMMddHHmm")));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_PTTT");
                element.AppendChild(doc.CreateTextNode(dr["MaPTTT"].ToString()));
                chitiet.AppendChild(element);
            }
            //
            return doc;
        }
        public static XmlDocument XML3_4210(DataTable dataTable, string MaBenh)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement danhsach = doc.CreateElement("DSACH_CHI_TIET_DVKT");
            doc.AppendChild(danhsach);
            foreach (DataRow dr in dataTable.Rows)
            {
                XmlElement chitiet = doc.CreateElement("CHI_TIET_DVKT");
                danhsach.AppendChild(chitiet);

                XmlElement element = doc.CreateElement("MA_LK");
                element.AppendChild(doc.CreateTextNode(dr["MaLK"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("STT");
                element.AppendChild(doc.CreateTextNode(dr["STT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_DICH_VU");
                element.AppendChild(doc.CreateTextNode(dr["MaDichVu"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_VAT_TU");
                element.AppendChild(doc.CreateTextNode(dr["MaVT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_NHOM");
                element.AppendChild(doc.CreateTextNode(dr["MaNhom"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("GOI_VTYT");
                element.AppendChild(doc.CreateTextNode(dr["GoiVTYT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("TEN_VAT_TU");
                element.AppendChild(doc.CreateCDataSection(dr["TenVatTu"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("TEN_DICH_VU");
                element.AppendChild(doc.CreateCDataSection(dr["TenDichVu"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("DON_VI_TINH");
                element.AppendChild(doc.CreateTextNode(dr["DonViTinh"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("PHAM_VI");
                element.AppendChild(doc.CreateTextNode(dr["PhamVi"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("SO_LUONG");
                element.AppendChild(doc.CreateTextNode(dr["SoLuong"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("DON_GIA");
                element.AppendChild(doc.CreateTextNode(dr["DonGia"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("TT_THAU");
                element.AppendChild(doc.CreateTextNode(dr["TTinThau"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("TYLE_TT");
                element.AppendChild(doc.CreateTextNode(dr["TyLe"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("THANH_TIEN");
                element.AppendChild(doc.CreateTextNode(dr["ThanhTien"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_TRANTT");
                element.AppendChild(doc.CreateTextNode(dr["TTrantT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MUC_HUONG");
                element.AppendChild(doc.CreateTextNode(dr["MucHuong"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_NGUONKHAC");
                element.AppendChild(doc.CreateTextNode(dr["TienNguonKhac"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_BNTT");
                element.AppendChild(doc.CreateTextNode(dr["TienBNTT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_BHTT");
                element.AppendChild(doc.CreateTextNode(dr["TienBHTT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_BNCCT");
                element.AppendChild(doc.CreateTextNode(dr["TienBNCCT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("T_NGOAIDS");
                element.AppendChild(doc.CreateTextNode(dr["TienNgoaiDS"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_KHOA");
                element.AppendChild(doc.CreateTextNode((dr["MaKhoa"] + "_").Split('_')[0]));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_GIUONG");
                element.AppendChild(doc.CreateTextNode(dr["MaGiuong"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_BAC_SI");
                element.AppendChild(doc.CreateTextNode(dr["MaBacSi"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_BENH");
                element.AppendChild(doc.CreateTextNode(FixMaBenh(MaBenh)));
                chitiet.AppendChild(element);

                element = doc.CreateElement("NGAY_YL");
                element.AppendChild(doc.CreateTextNode(Utils.ToDateTime(dr["NgayYLenh"].ToString()).ToString("yyyyMMddHHmm")));
                chitiet.AppendChild(element);

                element = doc.CreateElement("NGAY_KQ");
                element.AppendChild(doc.CreateTextNode(Utils.ToDateTime(dr["NgayKQ"].ToString()).ToString("yyyyMMddHHmm")));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_PTTT");
                element.AppendChild(doc.CreateTextNode(dr["MaPTTT"].ToString()));
                chitiet.AppendChild(element);
            }
            //
            return doc;
        }
        public static XmlDocument XML4_4210(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement danhsach = doc.CreateElement("DSACH_CHI_TIET_CLS");
            doc.AppendChild(danhsach);
            foreach (DataRow dr in dataTable.Rows)
            {
                XmlElement chitiet = doc.CreateElement("CHI_TIET_CLS");
                danhsach.AppendChild(chitiet);

                XmlElement element = doc.CreateElement("MA_LK");
                element.AppendChild(doc.CreateTextNode(dr["MaLK"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("STT");
                element.AppendChild(doc.CreateTextNode(dr["STT"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_DICH_VU");
                element.AppendChild(doc.CreateTextNode(dr["MaDichVu"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_CHI_SO");
                element.AppendChild(doc.CreateTextNode(dr["MaChiSo"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("TEN_CHI_SO");
                element.AppendChild(doc.CreateCDataSection(dr["TenChiSo"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("GIA_TRI");
                element.AppendChild(doc.CreateCDataSection(dr["GiaTri"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MA_MAY");
                element.AppendChild(doc.CreateTextNode(dr["MaMay"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("MO_TA");
                element.AppendChild(doc.CreateCDataSection(dr["MoTa"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("KET_LUAN");
                element.AppendChild(doc.CreateCDataSection(dr["KetLuan"].ToString()));
                chitiet.AppendChild(element);

                element = doc.CreateElement("NGAY_KQ");
                element.AppendChild(doc.CreateTextNode(Utils.ToDateTime(dr["NgayKQ"].ToString()).ToString("yyyyMMddHHmm")));
                chitiet.AppendChild(element);
            }
            //
            return doc;
        }
        public static XmlDocument GIAMDINH(DanhSachHoSo danhSachHoSo)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement giamdinh = doc.CreateElement("GIAMDINHHS");
            doc.AppendChild(giamdinh);
            // THÔNG TIN ĐƠN VỊ
            XmlElement thongtinDonVi = doc.CreateElement("THONGTINDONVI");
            giamdinh.AppendChild(thongtinDonVi);

            XmlElement element = doc.CreateElement("MACSKCB");
            element.AppendChild(doc.CreateTextNode("70013"));//element.AppendChild(doc.CreateTextNode(AppConfig.CoSoKCB));
            thongtinDonVi.AppendChild(element);

            // THÔNG TIN HỒ SƠ
            XmlElement thongtinHoSo = doc.CreateElement("THONGTINHOSO");
            giamdinh.AppendChild(thongtinHoSo);

            element = doc.CreateElement("NGAYLAP");
            element.AppendChild(doc.CreateTextNode(DateTime.Now.ToString("yyyyMMdd")));
            thongtinHoSo.AppendChild(element);

            element = doc.CreateElement("SOLUONGHOSO");
            element.AppendChild(doc.CreateTextNode(danhSachHoSo.Count.ToString()));
            thongtinHoSo.AppendChild(element);

            XmlElement danhsach = doc.CreateElement("DANHSACHHOSO");
            thongtinHoSo.AppendChild(danhsach);
            foreach (HoSo hoso in danhSachHoSo)
            {
                XmlElement elementHoSo = doc.CreateElement("HOSO");
                danhsach.AppendChild(elementHoSo);
                foreach (FileHoSo file in hoso)
                {
                    XmlElement elementFile = doc.CreateElement("FILEHOSO");
                    elementHoSo.AppendChild(elementFile);

                    XmlElement elementLoaiHS = doc.CreateElement("LOAIHOSO");
                    elementLoaiHS.AppendChild(doc.CreateTextNode(file.LoaiHoSo));
                    elementFile.AppendChild(elementLoaiHS);

                    XmlElement elementNoiDung = doc.CreateElement("NOIDUNGFILE");
                    elementNoiDung.AppendChild(doc.CreateTextNode(file.NoiDungFile));
                    elementFile.AppendChild(elementNoiDung);
                }
            }
            XmlElement chuKy = doc.CreateElement("CHUKYDONVI");
            giamdinh.AppendChild(chuKy);
            return doc;
        }
    }
}
