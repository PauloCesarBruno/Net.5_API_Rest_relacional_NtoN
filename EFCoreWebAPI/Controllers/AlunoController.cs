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
    public class AlunoController : ControllerBase
    {
        private readonly IEFWebApiRepository _repo;

        public AlunoController(IEFWebApiRepository repo)
        {
            _repo = repo;
        }

        // Get api/AlunoController
        [HttpGet]
        public async Task<IActionResult> GetAlunos()
        {
            try
            {
                var results = await _repo.GetAlunos();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
        }

        // Get api/AlunoController/5
        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> GetAlunoID(int AlunoId)
        {
            try
            {
                var results = await _repo.GetAlunoId(AlunoId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
        }

        // POST api/AlunoController
        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/Aluno/{model.AlunoId}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }

        // PUT api/AlunoController/5
        [HttpPut("{AlunoId}")]
        public async Task<IActionResult> Put(int AlunoId, Aluno model)
        {
            try
            {
                var results = await _repo.GetAlunoId(AlunoId);
                if (results == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Aluno/{model.AlunoId}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }

        // DELETE api/AlunoController/5
        [HttpDelete("{AlunoId}")]
        public async Task<IActionResult> Delete(int AlunoId)
        {
            try
            {
                var results = await _repo.GetAlunoId(AlunoId);
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
