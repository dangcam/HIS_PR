select SoPhieu,PN.MaVatTu,SoLuongQuyDoi,SoLuongDung,SoLuongXuat from
(select SoPhieu,SoLuongQuyDoi,SoLuongDung,MaVatTu from PhieuNhapChiTiet) as PN
left join
(select SoPhieuNhap,MaVatTu,SUM(SoLuong) as SoLuongXuat from PhieuXuatChiTiet group by SoPhieuNhap,MaVatTu) as PX
on PN.SoPhieu = PX.SoPhieuNhap and PN.MaVatTu = PX.MaVatTu
where SoLuongDung!=SoLuongXuat

select SoPhieu,PN.MaVatTu,SoLuongQuyDoi,SoLuongDung,SoLuongXuat from
(select SoPhieu,Sum(SoLuongQuyDoi)as SoLuongQuyDoi,Sum(SoLuongDung) as SoLuongDung,MaVatTu 
	from PhieuNhapChiTiet group by SoPhieu,MaVatTu) as PN
left join
(select SoPhieuNhap,MaVatTu,SUM(SoLuong) as SoLuongXuat from PhieuXuatChiTiet group by SoPhieuNhap,MaVatTu) as PX
on PN.SoPhieu = PX.SoPhieuNhap and PN.MaVatTu = PX.MaVatTu
where SoLuongDung!=SoLuongXuat 