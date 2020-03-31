Select TenVatTu,Kho.MaVatTu,SoLuong,SoLuongDung2,SoLuongDung,SoLuongDung3,SoLuongTon,
(Soluong - (SoLuongDung)) as SoLuongTon1 from 
(select MaVatTu,SUM(SoLuong) as SoLuong,SUM(SoLuong-SoLuongDung) as SoLuongTon,
	SUM(SoLuongDung) as SoLuongDung2
from PhieuXuatChiTiet where SUBSTRING(KhoNhan, 1, 3) = 'K01' group by MaVatTu) as Kho            
Left Join
(select MaVatTu,SUM(SoLuong) as SoLuongDung from DonThuocChiTiet where SUBSTRING(MaKhoa, 1, 3) = 'K01' group by MaVatTu) as Xuat
on Xuat.MaVatTu = Kho.MaVatTu
Left Join VatTu
on VatTu.MaBV = Kho.MaVatTu
Left Join
(select MaVatTu,SUM(SoLuong) as SoLuongDung3 from VatTuChiTiet where SUBSTRING(MaKhoa, 1, 3) = 'K01' group by MaVatTu) as XuatVT
on VatTu.MaBV = XuatVT.MaVatTu