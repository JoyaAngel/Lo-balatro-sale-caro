namespace GameStore.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public string ImagenUrl { get; set; }
    }
}
