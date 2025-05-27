using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly GameStoreDbContext _context;
        private readonly IWebHostEnvironment _env;

        public GamesController(GameStoreDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            return View(await _context.Games.ToListAsync());
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Game game, IFormFile imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    var fileName = Path.GetFileName(imageUrl.FileName);
                    var filePath = Path.Combine(_env.WebRootPath, "images", fileName);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await imageUrl.CopyToAsync(stream);
                    game.ImageUrl = "/images/" + fileName;
                }
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var game = await _context.Games.FindAsync(id);
            if (game == null) return NotFound();
            return View(game);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Game game, IFormFile? imageUrl)
        {
            // Obtener la imagen actual antes de validar el modelo
            var existingGame = await _context.Games.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
            if (existingGame == null) return NotFound();

            // Si no se sube una nueva imagen, mantener la actual antes de la validación
            if (imageUrl == null)
            {
                game.ImageUrl = existingGame.ImageUrl;
                // Quitar el error de validación para ImageUrl si existe
                ModelState.Remove("ImageUrl");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageUrl != null)
                    {
                        var fileName = Path.GetFileName(imageUrl.FileName);
                        var filePath = Path.Combine(_env.WebRootPath, "images", fileName);
                        using var stream = new FileStream(filePath, FileMode.Create);
                        await imageUrl.CopyToAsync(stream);
                        game.ImageUrl = $"/images/{fileName}";
                    }
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
