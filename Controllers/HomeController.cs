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
        private ParticipantService _participantService;

        public HomeController(ILogger<HomeController> logger, CacheService cacheService, ApplicationContext context, ParticipantService participantService)
        {
            _logger = logger;
            _cacheService = cacheService;
            _context = context;
            _participantService = participantService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _participantService.GetRandomPairAsync(2));
            //return View(await _context.Participants.ToListAsync());
        }

        public async Task<IActionResult> Leaderboard()
        {
            var participants = _context.Participants
            .OrderByDescending(p => p.Rating)
            .ToList();

            // Pass the sorted list of participants to the view.
            return View(participants);
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

        [HttpPost]
        public async Task<IActionResult> IncreaseRating(int id)
        {
            //_participantService.IncreaseRating(id);
            var participant = await _context.Participants.FindAsync(id);

            if (participant != null)
            {
                participant.Rating++;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}