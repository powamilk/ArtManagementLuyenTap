using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Artist
    {
        public Artist()
        {
            Artworks = new HashSet<Artwork>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; } = null!;
        public string? Bio { get; set; }
        public string? Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ImagePath { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}
