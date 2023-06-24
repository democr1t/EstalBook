using EstalBook.Models;
using EstalBook.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace EstalBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CacheService _cacheService;
        private ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, CacheService cacheService, ApplicationContext context)
        {
            _logger = logger;
            _cacheService = cacheService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Participants.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Participant participant, IFormFile file)
        {
            Console.WriteLine("THIS IS IMAGEL ---------->" + participant.ProfileImage);

            _context.Participants.Add(participant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));   

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}