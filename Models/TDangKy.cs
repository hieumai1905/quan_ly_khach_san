using System;
using System.Collections.Generic;

namespace HotelManagements.Models;

public partial class TDangKy
{
    public string MaDk { get; set; } = null!;

    public string? MaKh { get; set; }

    public string? SoPhong { get; set; }

    public DateTime? NgayVao { get; set; }

    public DateTime? NgayRa { get; set; }

    public virtual TChiTietKh? MaKhNavigation { get; set; }

    public virtual TSoPhongLoaiPhong? SoPhongNavigation { get; set; }

    public virtual TDoanhThu? TDoanhThu { get; set; }
}
