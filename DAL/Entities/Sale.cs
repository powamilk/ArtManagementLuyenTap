using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int? ArtworkId { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? SalePrice { get; set; }
        public string? ImagePath { get; set; }

        public virtual Artwork? Artwork { get; set; }
    }
}
