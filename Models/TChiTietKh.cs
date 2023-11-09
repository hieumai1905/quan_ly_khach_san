using System;
using System.Collections.Generic;

namespace HotelManagements.Models;

public partial class TChiTietKh
{
    public string MaKh { get; set; } = null!;

    public string? LoaiKh { get; set; }

    public string? TenKh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool Phai { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public int? DiemTichLuy { get; set; }

    public string? TheCanCuoc { get; set; }

    public virtual TLoaiKhachHang? LoaiKhNavigation { get; set; }

    public virtual ICollection<TDangKy> TDangKies { get; set; } = new List<TDangKy>();

    public virtual ICollection<TDatPhong> TDatPhongs { get; set; } = new List<TDatPhong>();
}
