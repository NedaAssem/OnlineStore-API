using System;
using System.Collections.Generic;

namespace OnlineStore.Data.Entities;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? ProductId { get; set; }

    public int? CustomerId { get; set; }

    public string? ReviewText { get; set; }

    public decimal Rating { get; set; }

    public DateTime ReviewDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ProductCatalog? Product { get; set; }
}
