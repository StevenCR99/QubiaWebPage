using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QubiaWebPage.Models;

namespace QubiaWebPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QubiaDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeController(
            ILogger<HomeController> logger,
            QubiaDbContext context,
            IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var infoEmpresa = _context.EmpresaInfo.ToList();
            return View(infoEmpresa);
        }

        public IActionResult Careers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Careers(Solicitude model, IFormFile cv)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (cv != null && cv.Length > 0)
            {
                var carpeta = Path.Combine(_env.WebRootPath, "cvs");

                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                var nombreArchivo = Guid.NewGuid() + Path.GetExtension(cv.FileName);
                var rutaCompleta = Path.Combine(carpeta, nombreArchivo);

                using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    cv.CopyTo(stream);
                }

                model.CVRuta = "/cvs/" + nombreArchivo;
            }

            _context.Solicitudes.Add(model);
            _context.SaveChanges();

            TempData["Success"] = "Solicitud enviada con éxito";

            return RedirectToAction("Careers");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
