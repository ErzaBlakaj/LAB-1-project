using System;

namespace lab1_project.Models
{
    public class GetAutobusatById
    {
        public int? Id { get; set; }
        public string? Persjkrimi { get; set; }
        public string? Targat { get; set; }
        public DateTime? DataERegjistrimit { get; set; }
        public DateTime? DataESkadimitTeRegjistrimit { get; set; }
        public string? NrShsise { get; set; }
    }
}
