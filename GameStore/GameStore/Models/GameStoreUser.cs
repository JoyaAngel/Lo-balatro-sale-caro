using Microsoft.AspNetCore.Identity;


namespace GameStore.Models
{
    public class GameStoreUser : IdentityUser
    {

        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }

    }
}
