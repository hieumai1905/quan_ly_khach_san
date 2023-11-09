using System;
using System.Collections.Generic;

namespace HotelManagements.Models;

public partial class TChiTietDatPhong
{
    public string MaDp { get; set; } = null!;

    public string LoaiPhong { get; set; } = null!;

    public byte SlphongDat { get; set; }

    public virtual TLoaiPhong LoaiPhongNavigation { get; set; } = null!;

    public virtual TDatPhong MaDpNavigation { get; set; } = null!;
}
