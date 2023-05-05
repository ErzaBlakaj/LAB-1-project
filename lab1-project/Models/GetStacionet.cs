using System;

namespace lab1_project.Models
{
    public class GetStacionet
    {
        public int? Id { get; set; }
        public string? Emri { get; set; }
        public string? Adresa { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public decimal? Kodi_Postal { get; set; }
    }
}
