using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagements.Models;

public partial class TDanhGium
{
    public string MaDg { get; set; } = null!;

    public string? NoiDung { get; set; }

    public string? NguoiDanhGia { get; set; }
    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public string? ViTri { get; set; }

    public string? PhucVu { get; set; }

    public string? TienNghi { get; set; }

    public string? GiaCa { get; set; }

    public string? VeSinh { get; set; }

    public string? MonAn { get; set; }
}
