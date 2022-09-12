using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using WebPropia31.Context;
using WebPropia31.Models;

var builder = WebApplication.CreateBuilder(args);


//Creamos la base de datos
builder.Services.AddSqlServer<FutbolContext>(builder.Configuration.GetConnectionString("cnFutbol"));
builder.Services.AddRazorPages();

var app = builder.Build();

// Get
app.MapGet("/dbconexion", ([FromServices] FutbolContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("BBDD en memoria!");
});
app.MapGet("/verJugadores", ([FromServices] FutbolContext dbContext) =>
{
    return Results.Ok(dbContext.Jugadores);
});
app.MapGet("/verEquipos", ([FromServices] FutbolContext dbContext) =>
{
    return Results.Ok(dbContext.Equipos);
});

// Post
app.MapPost("/nuevoJugador", async ([FromServices] FutbolContext dbContext, [FromBody] Jugador jugador) =>
{
    await dbContext.AddAsync(jugador);

    await dbContext.SaveChangesAsync();

    return Results.Ok("Nuevo jugador fichado!");
});
app.MapPost("/crearEquipo", async ([FromServices] FutbolContext dbContext, [FromBody] Equipo equipo) =>
{
    await dbContext.AddAsync(equipo);

    await dbContext.SaveChangesAsync();

    return Results.Ok("Equipo creado");
});

app.MapPut("/editarJugador/{id}", async ([FromServices] FutbolContext dbContext, [FromBody] Jugador jugador, [FromRoute] int id) =>
{
    var jugadorActual = dbContext.Jugadores.Find(id);

    if (jugador != null)
    {
        jugadorActual.NombreJugador = jugador.NombreJugador;
        jugadorActual.ApellidoJugador = jugador.ApellidoJugador;
        jugadorActual.IdEquipo = jugador.IdEquipo;

        await dbContext.SaveChangesAsync();

        return Results.Ok("Jugador actualizada correctamente!");

    }

    return Results.NotFound("esto no existe!");
});
app.MapPut("/editarEquipo/{id}", async ([FromServices] FutbolContext dbContext, [FromBody] Equipo equipo, [FromRoute] int id) =>
{
    var equipoActual = dbContext.Equipos.Find(id);

    if (equipo != null)
    {
        equipoActual.Nombre = equipo.Nombre;
        equipoActual.Color = equipo.Color;
        equipoActual.Campeonatos = equipo.Campeonatos;

        await dbContext.SaveChangesAsync();

        return Results.Ok("Equipo actualizada correctamente!");

    }

    return Results.NotFound("esto no existe!");
});

app.UseHttpsRedirection();

app.UseStaticFiles(); // Para estilos
app.UseRouting();
app.MapRazorPages(); // Para mapear paginas razor

app.Run();
