using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebPropia31.Context;
using WebPropia31.Models;

namespace WebPropia31.Pages.Equipos
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
        public IEnumerable<Equipo> EquiposListados { get; set; }

        // Metodo asincrono para llamar a la conexion
        public async Task OnGet()
        {
            EquiposListados = await _contexto.Equipos.ToListAsync();
        }
    }
}
