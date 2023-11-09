using System;
using System.Collections.Generic;

namespace HotelManagements.Models;

public partial class TDatPhong
{
    public string MaDp { get; set; } = null!;

    public string? MaKh { get; set; }

    public string? Diachi { get; set; }

    public string? TenCongTy { get; set; }

    public string? MaSoThue { get; set; }

    public string? DiaChiCty { get; set; }

    public virtual TChiTietKh? MaKhNavigation { get; set; }

    public virtual ICollection<TChiTietDatPhong> TChiTietDatPhongs { get; set; } = new List<TChiTietDatPhong>();
}
