using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.Utils;

namespace OtoServisSatis.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]

    public class CarsController : Controller
    {
        private readonly ICarService _service;
        private readonly IService<Marka> _serviceMarka;

        public CarsController(ICarService service, IService<Marka> serviceMarka)
        {
            _service = service;
            _serviceMarka = serviceMarka;
        }

        // GET
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetCustomCarList();
            return View(model);
        }

        // GET
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Arac arac, IFormFile? Resim1, IFormFile? Resim2, IFormFile? Resim3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    arac.Resim1 = await FileHelper.FileLoaderAsync(Resim1, "Img/Cars/");
                    arac.Resim2 = await FileHelper.FileLoaderAsync(Resim2, "Img/Cars/");
                    arac.Resim3 = await FileHelper.FileLoaderAsync(Resim3, "Img/Cars/");
                    await _service.AddAsync(arac);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");
                }
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(arac);
        }

        // GET
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");

            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Arac arac, IFormFile? Resim1, IFormFile? Resim2, IFormFile? Resim3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Resim1 is not null)
                    {
                        arac.Resim1 = await FileHelper.FileLoaderAsync(Resim1, "Img/Cars/");
                    }
                    if (Resim2 is not null)
                    {
                        arac.Resim2 = await FileHelper.FileLoaderAsync(Resim2, "Img/Cars/");
                    }
                    if (Resim3 is not null)
                    {
                        arac.Resim3 = await FileHelper.FileLoaderAsync(Resim3, "Img/Cars/");

                    }
                    _service.Update(arac);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");
                }
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(arac);
        }

        // GET
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Arac arac)
        {
            try
            {
                _service.Delete(arac);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
