using System;
using System.Collections.Generic;

namespace OnlineStore.Data.Entities;

public partial class OrderItem
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal TotalItemsPrice { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ProductCatalog Product { get; set; } = null!;
}
