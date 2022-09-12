using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;
using WebPropia31.Context;
using WebPropia31.Models;

namespace WebPropia31.Pages.Jugadores
{
    public class nuevoJugadorModel : PageModel
    {
        //Traigo una instancia del contexto para vincular
        private readonly FutbolContext _contexto;

        //Defino el constructor de la clase
        public nuevoJugadorModel(FutbolContext contexto)
        {
            _contexto = contexto;
        }
        //Traemos el modelo y le hacemos binding
        [BindProperty]
        public Jugador jugadorGuardable { set; get; }

        //Metodo asincrono para guardar la informacion
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Añadir el objeto jugador
            _contexto.Add(jugadorGuardable);
            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
