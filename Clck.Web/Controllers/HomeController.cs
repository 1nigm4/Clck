using Clck.DAL.Repositories;
using Clck.Domain.Models;
using Clck.Web.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Clck.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LinkManager _linkManager;
        private readonly Random _random;

        public HomeController(
            ILogger<HomeController> logger,
            Random random,
            LinkManager linkManager)
        {
            _logger = logger;
            _random = random;
            _linkManager = linkManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(string id)
        {
            Link? link = await _linkManager.GetAsync(id);
            Request.RouteValues["id"] = null;
            if (link == null) return RedirectToAction(nameof(Index));
            return Redirect($"//{link.Url}");
        }

        [HttpGet]
        public async Task<IActionResult> Create(string url)
        {
            Link? link = await _linkManager.GetByUrlAsync(url);
            link ??= await _linkManager.CreateAsync(url);
            return Json(link);
        }
    }
}