namespace Library.WebApi.Models
{
    public class Calification
    {
        public int Id { get; set; }
        public int Puntuacion { get; set; }
        public string Reseña { get; set; }
        public int BookId { get; set; }
    }
}
