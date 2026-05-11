using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product, IFormFile? ImageFile)
        {
            if (ImageFile != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                var path = Path.Combine(_env.WebRootPath, "images", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                ImageFile.CopyTo(stream);
                product.ImageUrl = "/images/" + fileName;
            }

            if (!ModelState.IsValid) return View(product);
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product, IFormFile? ImageFile)
        {
            if (ImageFile != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                var path = Path.Combine(_env.WebRootPath, "images", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                ImageFile.CopyTo(stream);
                product.ImageUrl = "/images/" + fileName;
            }

            if (!ModelState.IsValid) return View(product);
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}