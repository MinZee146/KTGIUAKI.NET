using System;
using System.Collections.Generic;

namespace WebECommerce.Models;

public partial class TLoaiDt
{
    public string MaDt { get; set; } = null!;

    public string? TenLoai { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();
}
