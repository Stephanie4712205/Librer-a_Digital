namespace Library.WebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Título { get; set; }
        public string Autor { get; set; }
        public string AñoPublicacion { get; set; }
        public int UserId { get; set; }
    }
}
