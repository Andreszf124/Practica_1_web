namespace Practica_1_web.Application.DTOs
{
    public class TelefonoDto
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int ClienteId { get; set; }
    }
}
