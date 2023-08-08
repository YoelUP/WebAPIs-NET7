using CURSOC_.Data;
using CURSOC_.Models;
using CURSOC_.Models.DTO;
using CURSOC_.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CURSOC_.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class ProvinciaController : ControllerBase
    {
        private readonly ILogger<ProvinciaController> _logger;
        private readonly IProvinciaC _context;
        protected APIRespose _response;

        #region Controlador
        public ProvinciaController(ILogger<ProvinciaController> logger, IProvinciaC context)
        {
            _logger = logger;
            _context = context;
            _response = new();
        }
        #endregion

        #region GetAll
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIRespose>> GetProvincias()
        {
            try
            {
                _logger.LogInformation("Carga de Provincias");
                _response.statusCode = System.Net.HttpStatusCode.OK;
                _response.Result = await _context.ObtainAll();
                return Ok(_response);
            }
            catch (Exception e)
            {

                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }
        #endregion

        #region Get
        [HttpGet("id:int", Name = "GETPROVINCIA")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIRespose>> GetProvincia(int id)
        {
            try
            {
                var prov = await _context.Obtain(p => p.conprovincia == id);
                if (prov == null)
                {
                    _response.statusCode = System.Net.HttpStatusCode.NotFound;
                }
                _response.statusCode = System.Net.HttpStatusCode.OK;
                _response.Result = prov;
                return Ok(_response);

            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIRespose>> PostProvincia([FromBody] ProvinciaDTO prov)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await _context.Obtain(p => p.nomprovincia.ToLower() == prov.nomprovincia.ToLower()) != null)
                {
                    ModelState.AddModelError("Exist", "The Provincia Exist ");
                    return BadRequest(ModelState);
                }

                if (prov == null)
                {
                    return BadRequest();
                }

                ProvinciaC provModel = new()
                {
                    nomprovincia = prov.nomprovincia
                };

                await _context.Create(provModel);
                await _context.Save();
                _response.statusCode = System.Net.HttpStatusCode.OK;
                _response.Result = provModel;
                return Ok(_response);

            }
            catch (Exception e)
            {

                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
                return BadRequest(e.Message);
            }

        }
        #endregion

        #region Delete
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIRespose>> DeleteProvincia(int id)
        {
            try
            {
                if (id == 0)
                {
                    BadRequest();
                }
                var prov = await _context.Obtain(p => p.conprovincia == id);
                if (prov == null)
                {
                    _response.IsSuccessful = false;
                    _response.statusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = prov;
                _ = _context.Delete(prov);
                _response.statusCode = System.Net.HttpStatusCode.NoContent;
                return _response;
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Put
        [HttpPut("(id:int)")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIRespose>> PutProvincia(int id, [FromBody] ProvinciaDTO provDTO)
        {
            try
            {
                ProvinciaC provModel = new()
                {
                    conprovincia = id,
                    nomprovincia = provDTO.nomprovincia
                };

                await _context.UpdateP(provModel);
                _response.Result = provModel;
                _response.statusCode = System.Net.HttpStatusCode.NoContent;
                await _context.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
                return BadRequest(e.Message);
            }
        } 
        #endregion
    }
}