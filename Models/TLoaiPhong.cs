using System;
using System.Collections.Generic;

namespace HotelManagements.Models;

public partial class TLoaiPhong
{
    public string LoaiPhong { get; set; } = null!;

    public string? MoTa { get; set; }

    public int? DonGia { get; set; }

    public string? HinhAnh { get; set; }

    public string? DienTich { get; set; }

    public string? SoGiuong { get; set; }

    public string? SoPhongNgu { get; set; }

    public string? BonTam { get; set; }

    public string? SoPhongTam { get; set; }

    public double? Gia { get; set; }

    public virtual ICollection<TChiTietDatPhong> TChiTietDatPhongs { get; set; } = new List<TChiTietDatPhong>();

    public virtual ICollection<TSoPhongLoaiPhong> TSoPhongLoaiPhongs { get; set; } = new List<TSoPhongLoaiPhong>();
}
