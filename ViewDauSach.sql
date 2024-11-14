CREATE VIEW ViewDauSach AS
SELECT 
    ds.Ma_Dau_Sach,
    ds.Ten_Dau_Sach,
    ds.Nam_Xuat_Ban,
    ds.Gia_Bia,
    ds.Ma_NXB,
    nxb.Ten_NXB,
    ds.Ma_Kho,
    k.Ten_Kho,
    ds.Ma_Chu_De,
    cd.Ten_Chu_De,
    ds.Ma_TL,
    tl.Ten_The_Loai,
    STRING_AGG(tgds.Ma_Tac_Gia, ', ') AS Ma_Tac_Gia,
    STRING_AGG(tg.Ten_Tac_Gia, ', ') AS Ten_Tac_Gia
FROM 
    DauSach ds
    LEFT JOIN TacGia_DauSach tgds ON ds.Ma_Dau_Sach = tgds.Ma_Dau_Sach
    LEFT JOIN TacGia tg ON tgds.Ma_Tac_Gia = tg.Ma_Tac_Gia
    LEFT JOIN NXB nxb ON ds.Ma_NXB = nxb.Ma_NXB
    LEFT JOIN ChuDe cd ON ds.Ma_Chu_De = cd.Ma_Chu_De
    LEFT JOIN Kho k ON ds.Ma_Kho = k.Ma_Kho
    LEFT JOIN TheLoai tl ON ds.Ma_TL = tl.Ma_The_Loai
GROUP BY 
    ds.Ma_Dau_Sach,
    ds.Ten_Dau_Sach,
    ds.Nam_Xuat_Ban,
    ds.Gia_Bia,
    ds.Ma_NXB,
    nxb.Ten_NXB,
    ds.Ma_Kho,
    k.Ten_Kho,
    ds.Ma_Chu_De,
    cd.Ten_Chu_De,
    ds.Ma_TL,
    tl.Ten_The_Loai;
