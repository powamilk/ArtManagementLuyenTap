using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Gallery
    {
        public int GalleryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
        public string? ImagePath { get; set; }
    }
}
