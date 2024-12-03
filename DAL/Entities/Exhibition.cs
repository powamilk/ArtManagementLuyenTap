using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Exhibition
    {
        public int ExhibitionId { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ImagePath { get; set; }
    }
}
