select SoPhieuNhap,SUM(SoLuong) from PhieuXuatChiTiet where MaVatTu = 'KTS' group by MaVatTu,SoPhieuNhap

select SoPhieu,SUM(SoLuongQuyDoi) from PhieuNhapChiTiet where MaVatTu = 'KTS' group by MaVatTu,SoPhieu
