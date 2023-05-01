namespace lab1_project.Models
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Email { get; set; }
        public int? Id_role { get; set; }
    }
}
