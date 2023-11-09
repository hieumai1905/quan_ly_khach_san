using System;
using System.Collections.Generic;

namespace HotelManagements.Models;

public partial class TSoPhongLoaiPhong
{
    public string SoPhong { get; set; } = null!;

    public string LoaiPhong { get; set; } = null!;

    public virtual TLoaiPhong LoaiPhongNavigation { get; set; } = null!;

    public virtual ICollection<TDangKy> TDangKies { get; set; } = new List<TDangKy>();
}
