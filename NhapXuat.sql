select * from
(select SoPhieu,MaVatTu,SUM(SoLuongQuyDoi) as Nhap, SUM(SoLuongDung) as Dung from PhieuNhapChiTiet Group By SoPhieu,MaVatTu) as Nhap,
(select SoPhieuNhap,MaVatTu,Sum(SoLuong) as Xuat from PhieuXuatChiTiet Group By SoPhieuNhap,MaVatTu) as Xuat
where Nhap.SoPhieu = Xuat.SoPhieuNhap and Nhap.MaVatTu = Xuat.MaVatTu
order by Xuat.MaVatTu
