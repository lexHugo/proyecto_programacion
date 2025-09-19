using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto_programacion.Data;
using proyecto_programacion.Models;

namespace proyecto_programacion.Controllers;

public class ActivosController : Controller
{
    private readonly ApplicationDbContext _context;

    public ActivosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Activos (Página principal que muestra la lista)
    public async Task<IActionResult> Index()
    {
        var activos = _context.Activos
            .Include(a => a.Categoria)
            .Include(a => a.Ubicacion);
        return View(await activos.ToListAsync());
    }

    // GET: Activos/Details/5 (Ver el detalle de un activo)
        public async Task<IActionResult> Detalles(int? id)
    {
        if (id == null) return NotFound();

        var activo = await _context.Activos
            .Include(a => a.Categoria)
            .Include(a => a.Ubicacion)
            .FirstOrDefaultAsync(m => m.activo_id == id);
        
        if (activo == null) return NotFound();
        return View(activo);
    }

    // GET: Activos/Create (Muestra el formulario para crear)
    public IActionResult Creacion()
    {
        // Asegúrate que "categ_id" y "nom_categoria" sean los nombres EXACTOS de las propiedades en tu Categoria.cs
        ViewData["categ_id"] = new SelectList(_context.Categorias, "categ_id", "nom_categoria"); 
        
        // Asegúrate que "ubic_id" y "nom_ubica" sean los nombres EXACTOS de las propiedades en tu Ubicacion.cs
        ViewData["ubic_id"] = new SelectList(_context.Ubicaciones, "ubic_id", "nom_ubica");
        
        return View();
    }

    // POST: Activos/Create (Recibe los datos del formulario y los guarda)
    [HttpPost]
    [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creacion([Bind("activo_id,nom_act,cod_act,modelo,num_serie,costo,fecha_com,proveedor,estado,categ_id,ubic_id")] Activo activo)
    {
        if (ModelState.IsValid)
        {
            _context.Add(activo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["categ_id"] = new SelectList(_context.Categorias, "categ_id", "nom_categoria", activo.categ_id);
        ViewData["ubic_id"] = new SelectList(_context.Ubicaciones, "ubic_id", "nom_ubica", activo.ubic_id);
        return View(activo);
    }

    // GET: Activos/Edit/5 (Muestra el formulario para editar)
    public async Task<IActionResult> Editar(int? id)
    {
        if (id == null) return NotFound();
    var activo = await _context.Activos.FindAsync(id);
    if (activo == null) return NotFound();
        
    ViewData["categ_id"] = new SelectList(_context.Categorias, "categ_id", "nom_categoria", activo.categ_id);
    ViewData["ubic_id"] = new SelectList(_context.Ubicaciones, "ubic_id", "nom_ubica", activo.ubic_id);
    return View(activo);
    }

    // POST: Activos/Edit/5 (Recibe los datos y los actualiza)
    [HttpPost]
    [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("activo_id,nom_act,cod_act,modelo,num_serie,costo,fecha_com,proveedor,estado,categ_id,ubic_id")] Activo activo)
    {
    if (id != activo.activo_id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(activo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivoExists(activo.activo_id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
    ViewData["categ_id"] = new SelectList(_context.Categorias, "categ_id", "nom_categoria", activo.categ_id);
    ViewData["ubic_id"] = new SelectList(_context.Ubicaciones, "ubic_id", "nom_ubica", activo.ubic_id);
    return View(activo);
    }

    // GET: Activos/Delete/5 (Muestra la página de confirmación para eliminar)
        public async Task<IActionResult> Eliminar(int? id)
    {
        if (id == null) return NotFound();

        var activo = await _context.Activos
            .Include(a => a.Categoria)
            .Include(a => a.Ubicacion)
            .FirstOrDefaultAsync(m => m.activo_id == id);
            
        if (activo == null) return NotFound();
        return View(activo);
    }

    // POST: Activos/Delete/5 (Confirma y elimina el registro)
    [HttpPost, ActionName("Eliminar")]
    [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
    {
    var activo = await _context.Activos.FindAsync(id);
        if (activo != null)
        {
            _context.Activos.Remove(activo);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ActivoExists(int id)
    {
    return _context.Activos.Any(e => e.activo_id == id);
    }
}
