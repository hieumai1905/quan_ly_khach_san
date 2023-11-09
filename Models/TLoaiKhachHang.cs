using System;
using System.Collections.Generic;

namespace HotelManagements.Models;

public partial class TLoaiKhachHang
{
    public string LoaiKh { get; set; } = null!;

    public string? DienGiai { get; set; }

    public virtual ICollection<TChiTietKh> TChiTietKhs { get; set; } = new List<TChiTietKh>();
}
