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
        private ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, CacheService cacheService, ApplicationContext context)
        {
            _logger = logger;
            _cacheService = cacheService;
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Participants.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Participant participant)
        {
            if (ModelState.IsValid)
            {
                // Save the profile image to the database
                if (participant.ProfileImage != null && participant.ProfileImage.Length > 0)
                {
                    using (var stream = new MemoryStream(participant.ProfileImage))
                    {
                        // Set the position of the stream to the beginning
                        stream.Position = 0;

                        // Copy the contents of the stream to a new memory stream
                        using (var memoryStream = new MemoryStream())
                        {
                            await stream.CopyToAsync(memoryStream);
                            participant.ProfileImage = memoryStream.ToArray();
                        }
                    }
                }
                    // Add the participant to the database
                  db.Participants.Add(participant);
                await db.SaveChangesAsync();

             
            }
            return RedirectToAction("Index");
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}