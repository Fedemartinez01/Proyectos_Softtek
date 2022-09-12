using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebPropia31.Context;
using WebPropia31.Models;

namespace WebPropia31.Pages.Jugadores
{
    public class IndexModel : PageModel
    {
        // Traigo una instancia del contexto para vincular
        private readonly FutbolContext _contexto;

        // Constructor
        public IndexModel(FutbolContext contexto)
        {
            _contexto = contexto;
        }

        // Defino coleccion para listar 
        public IEnumerable<Jugador> JugadoresListados { get; set; }
        public IEnumerable<Equipo> EquiposListados { get; set; }

        public string BuscarNombreEquipo(int id)
        {
            foreach (Equipo equipo in EquiposListados)
            {
                if(equipo.IdEquipo == id)
                {
                    return equipo.Nombre;
                }
            }
            return "Nop";
        }

        // Metodo asincrono para llamar a la conexion
        public async Task OnGet()
        {
            JugadoresListados = await _contexto.Jugadores.ToListAsync();
            EquiposListados = await _contexto.Equipos.ToListAsync();
        }
    }
}
