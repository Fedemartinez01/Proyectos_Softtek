using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebPropia31.Models
{
    [Table("Jugador")]
    public class Jugador
    {
        [Key]
        public int IdJugador { get; set; }
        [ForeignKey("IdEquipo")]
        public int IdEquipo { get; set; }
        public string NombreJugador { get; set; }
        public string ApellidoJugador { get; set; }
        public string EquipoNombre { get; set; }

        [JsonIgnore] // No me lo muestra en el postman
        public Equipo Equipo { get; set; }
        

    }
}
