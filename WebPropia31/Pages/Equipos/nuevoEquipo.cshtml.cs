using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPropia31.Context;
using WebPropia31.Models;

namespace WebPropia31.Pages.Equipos
{
    public class nuevoEquipoModel : PageModel
    {
        //Traigo una instancia del contexto para vincular
        private readonly FutbolContext _contexto;

        //Defino el constructor de la clase
        public nuevoEquipoModel(FutbolContext contexto)
        {
            _contexto = contexto;
        }
        //Traemos el modelo y le hacemos binding
        [BindProperty]
        public Equipo equipoGuardable { set; get; }

        //Metodo asincrono para guardar la informacion
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Añadir el objeto jugador
            _contexto.Add(equipoGuardable);
            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}