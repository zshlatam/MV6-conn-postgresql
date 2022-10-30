using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC6.Models;
using MVC6.Servicios;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC6.Controllers
{
    public class ImgController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly IRepositorioImg repositorioImg;

        public ImgController(IWebHostEnvironment env, IRepositorioImg repositorioImg)
        {
            _enviroment = env;
            this.repositorioImg = repositorioImg;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.message = TempData["message"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ImgViewModel img, string id)
        {
            var folderPath = System.IO.Path.Combine(_enviroment.ContentRootPath,
                "wwwroot/img/", id);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

            }

            var filename = System.IO.Path.Combine(_enviroment.ContentRootPath,
                "wwwroot/img/",id, img.Imagen1.FileName);

            var linkeado = "img/" + id +'/'+ img.Imagen1.FileName;
            img.link = linkeado ;
            await img.Imagen1.CopyToAsync(new System.IO.FileStream(
                filename, System.IO.FileMode.Create));

            repositorioImg.Crear(img);

            TempData["message"] = linkeado;
            return RedirectToAction("Index");
        }
    }
}

