CREATE VIEW chitietsach_full AS
SELECT 
    s.Ma_Sach,
    ds.Ma_Dau_Sach,
    ds.Ten_Dau_Sach,
    ds.Nam_Xuat_Ban,
    ds.Gia_Bia,
    tl.Ten_The_Loai,
    STRING_AGG(tg.Ten_Tac_Gia, ', ') AS Ten_Tac_Gia,
    nxb.Ten_NXB,
    cd.Ten_Chu_De,
    k.Ten_Kho,
    tt.Ten_Tinh_Trang
FROM 
    Sach s
    LEFT JOIN DauSach ds ON s.Ma_Dau_Sach = ds.Ma_Dau_Sach
    LEFT JOIN TheLoai tl ON ds.Ma_TL = tl.Ma_The_Loai
    LEFT JOIN TacGia_DauSach tgds ON ds.Ma_Dau_Sach = tgds.Ma_Dau_Sach
    LEFT JOIN TacGia tg ON tgds.Ma_Tac_Gia = tg.Ma_Tac_Gia
    LEFT JOIN NXB nxb ON ds.Ma_NXB = nxb.Ma_NXB
    LEFT JOIN ChuDe cd ON ds.Ma_Chu_De = cd.Ma_Chu_De
    LEFT JOIN Kho k ON ds.Ma_Kho = k.Ma_Kho
    LEFT JOIN TinhTrang tt ON s.Ma_Tinh_Trang = tt.Ma_Tinh_Trang
GROUP BY 
    s.Ma_Sach,
    ds.Ma_Dau_Sach,
    ds.Ten_Dau_Sach,
    ds.Nam_Xuat_Ban,
    ds.Gia_Bia,
    tl.Ten_The_Loai,
    nxb.Ten_NXB,
    cd.Ten_Chu_De,
    k.Ten_Kho,
    tt.Ten_Tinh_Trang;
