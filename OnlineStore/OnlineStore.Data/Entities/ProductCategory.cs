using System;
using System.Collections.Generic;

namespace OnlineStore.Data.Entities;

public partial class ProductCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ProductCatalog> ProductCatalogs { get; set; } = new List<ProductCatalog>();
}
