using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;
using WebPropia31.Context;
using WebPropia31.Models;

namespace WebPropia31.Pages.Jugadores
{
    public class editarJugadorModel : PageModel
    {
        //Traigo una instancia del contexto para vincular
        private readonly FutbolContext _contexto;

        //Defino el constructor de la clase
        public editarJugadorModel(FutbolContext contexto)
        {
            _contexto = contexto;
        }

        //Instanciamos el modelo y le hacemos binding con la vista
        [BindProperty]
        public Jugador JugadorEditable{ set; get; }
        //El siguiente metodo busca la informacion de BBDD para mostrar por pantalla
        public async Task OnGet(int id)
        {
            //El id lo trae desde la vista index
            JugadorEditable = await _contexto.Jugadores.FindAsync(id);
        }

        //El siguiente metodo actualiza la informacion
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Variable a editar
                var JugadorEditado = await _contexto.Jugadores.FindAsync(JugadorEditable.IdJugador);

                JugadorEditado.NombreJugador = JugadorEditable.NombreJugador;
                JugadorEditado.ApellidoJugador = JugadorEditable.ApellidoJugador;
                JugadorEditado.IdEquipo = JugadorEditable.IdEquipo;

                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
