using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]

    public class RolesController : Controller
    {
        private readonly IService<Rol> _service;

        public RolesController(IService<Rol> service)
        {
            _service = service;
        }

        // GET
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rol rol)
        {

            try
            {
                _service.Add(rol);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Rol rol)
        {
            try
            {
                _service.Update(rol);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Rol rol)
        {
            try
            {
                _service.Delete(rol);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
