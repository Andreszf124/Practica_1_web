namespace Practica_1_web.Domain.Entities
{
    public class Telefono
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // Celular, Casa, Oficina, etc.

        // Foreign Key
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
    }
}
