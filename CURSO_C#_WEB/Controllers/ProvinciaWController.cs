using CURSO_C__WEB.Models;
using CURSO_C__WEB.Models.DTO;
using CURSO_C__WEB.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CURSO_C__WEB.Controllers
{
    public class ProvinciaWController : Controller
    {
        private readonly IProvinciaService _provinciaService;

        public ProvinciaWController(IProvinciaService provinciaService)
        {
            _provinciaService = provinciaService;
        }

        public async Task<IActionResult> IndexProvincia()
        {
            List<ProvinciaDTO> provinciaList = new();
            var response = await _provinciaService.ObteinAllP<APIRespose>();
            if (response != null && response.IsSuccessful)
            {
                provinciaList = JsonConvert.DeserializeObject<List<ProvinciaDTO>>(Convert.ToString(response.Result));
            }
            return View(provinciaList);
        }

        //NO definido es un metodo Get, llama vista
        public async Task<IActionResult> CreateProvincia()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//SEGURIDAD PARA ENVIO DE DATOS
        public async Task<IActionResult> CreateProvincia(ProvinciaDTO provinciaDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _provinciaService.CreateP<APIRespose>(provinciaDTO);
                if (response != null && response.IsSuccessful)
                {
                    return RedirectToAction(nameof(IndexProvincia));
                }
            }
            return View(provinciaDTO);
        }
    }
}
