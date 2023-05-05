using System;
using System.Data;

namespace lab1_project.Models
{
    public class Autobusat
    {
        public int? Id { get; set; }
        public string? Pershkrimi { get; set; }
        public string Targat { get; set; }
        public DateTime? DataERegjistrimit { get; set; }
        public DateTime? DataESkadimitTeRegjistrimit{ get; set; }
        public string? NrShasise { get; set; } 
    }
}

