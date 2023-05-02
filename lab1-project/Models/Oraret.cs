using System;

namespace lab1_project.Models
{
	public class Oraret
	{
		public int? Id { get; set; }
		public string? Emri_i_linjes { get; set; }
		public int? Numri_i_orarit { get; set; }
		public TimeSpan? Ora_e_nisjes { get; set; }
		public TimeSpan? Ora_e_mberritjes { get; set; }
		public string? stacioni_i_nisjes { get; set; }
		public string? stacioni_i_mberritjes { get; set; }
		public int? Id_Linjat { get; set; }

	}
}

