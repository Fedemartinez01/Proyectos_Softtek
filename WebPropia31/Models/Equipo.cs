using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebPropia31.Models
{
    [Table("Equipo")]
    public class Equipo
    {
        [Key]
        public int IdEquipo { get; set; }     
        public string Nombre { get; set; }
        public string Color { get; set; }
        public int Campeonatos { get; set; }
        [JsonIgnore]
        public ICollection<Jugador>? Jugadores { get; set; }
    }
}
