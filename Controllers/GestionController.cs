using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto_programacion.Data;
using proyecto_programacion.Models;

namespace proyecto_programacion.Controllers;

public class GestionController : Controller
{
    private readonly ApplicationDbContext _context;

    public GestionController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Categorias()
    {
        var viewModel = new CategoriaViewModel
        {
            CategoriasExistentes = await _context.Categorias.ToListAsync(),
            NuevaCategoria = new Categoria()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CrearCategoria(Categoria nuevaCategoria)
    {
        if (ModelState.IsValid)
        {
            _context.Add(nuevaCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Categorias));
        }
        
        var viewModel = new CategoriaViewModel
        {
            CategoriasExistentes = await _context.Categorias.ToListAsync(),
            NuevaCategoria = nuevaCategoria
        };
        return View("Categorias", viewModel);
    }

    public async Task<IActionResult> Ubicaciones()
    {
        var viewModel = new UbicacionViewModel
        {
            UbicacionesExistentes = await _context.Ubicaciones.ToListAsync(),
            NuevaUbicacion = new Ubicacion()
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CrearUbicacion(Ubicacion nuevaUbicacion)
    {
        if (ModelState.IsValid)
        {
            _context.Add(nuevaUbicacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Ubicaciones));
        }
        
        var viewModel = new UbicacionViewModel
        {
            UbicacionesExistentes = await _context.Ubicaciones.ToListAsync(),
            NuevaUbicacion = nuevaUbicacion
        };
        return View("Ubicaciones", viewModel);
    }
}
