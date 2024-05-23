using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Data.Migrations;
using OtoServisSatis.Entities;
using OtoServisSatis.Models;
using OtoServisSatis.Service.Abstract;
using System.Diagnostics;
using Slider = OtoServisSatis.Entities.Slider;

namespace OtoServisSatis.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Slider> _service;

        public HomeController(IService<Slider> service)
        {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
