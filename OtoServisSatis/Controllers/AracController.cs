using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.Controllers
{
    public class AracController : Controller
    {
        private readonly ICarService _serviceArac;

        public AracController(ICarService serviceArac)
        {
            _serviceArac = serviceArac;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _serviceArac.GetCustomCar(id);
            return View(model);
        }
    }
}
