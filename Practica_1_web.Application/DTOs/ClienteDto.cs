namespace Practica_1_web.Application.DTOs
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public List<TelefonoDto> Telefonos { get; set; } = new List<TelefonoDto>();
    }
}
