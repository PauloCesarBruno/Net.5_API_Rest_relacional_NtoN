using EFCoreWebAPI.EFCoreWebAPIDomain.Model;
using EFCoreWebAPI.EFCoreWebAPIRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IEFWebApiRepository _repo;

        public CategoriaController(IEFWebApiRepository repo)
        {
            _repo = repo;
        }

        // Get api/CategoriaController
        [HttpGet]
        public async Task<IActionResult> GetCategoria()
        {
            try
            {
                var results = await _repo.GetCategorias();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
        }

        // Get api/CategoriaController/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoriaId(int Id)
        {
            try
            {
                var results = await _repo.GetCategoriaId(Id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
        }

        // POST api/CategoriaController
        [HttpPost]
        public async Task<IActionResult> Post(Categoria model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/Categoria/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }

        // PUT api/CategoriaController/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, Categoria model)
        {
            try
            {
                var results = await _repo.GetCategoriaId(Id);
                if (results == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Categoria/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }

        // DELETE api/CategoriaController/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var results = await _repo.GetCategoriaId(Id);
                if (results == null) return NotFound();
                {
                    _repo.Delete(results);

                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }
    }
}
