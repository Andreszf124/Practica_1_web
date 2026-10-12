namespace Practica_1_web.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

        // Relación 1:N con Telefono
        public ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
    }
}
