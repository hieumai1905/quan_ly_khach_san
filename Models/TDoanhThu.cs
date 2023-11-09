using System;
using System.Collections.Generic;

namespace HotelManagements.Models;

public partial class TDoanhThu
{
    public string MaDk { get; set; } = null!;

    public string? LoaiPhong { get; set; }

    public int? SoNgayO { get; set; }

    public double? ThucThu { get; set; }

    public virtual TDangKy MaDkNavigation { get; set; } = null!;
}
