using System;
using System.Collections.Generic;

namespace OnlineStore.Data.Entities;

public partial class ProductImage
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public short ImageOrder { get; set; }

    public int ProductId { get; set; }

    public virtual ProductCatalog Product { get; set; } = null!;
}
