using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Artwork
    {
        public Artwork()
        {
            Sales = new HashSet<Sale>();
        }

        public int ArtworkId { get; set; }
        public string Title { get; set; } = null!;
        public int? ArtistId { get; set; }
        public int? YearCreated { get; set; }
        public string? Medium { get; set; }
        public string? ImagePath { get; set; }

        public virtual Artist? Artist { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
