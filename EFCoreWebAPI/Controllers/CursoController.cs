using EFCoreWebAPI.EFCoreWebAPIDomain.Model;
using EFCoreWebAPI.EFCoreWebAPIRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EFCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IEFWebApiRepository _repo;

        public CursoController(IEFWebApiRepository repo)
        {
            _repo = repo;
        }

        //Get api/CursoController
        [HttpGet]
        public async Task<IActionResult> GetCursos()
        {
            try
            {
                var results = await _repo.GetCursos();
                return Ok(results);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
        }

        //Get api/CursoController/5
        [HttpGet("{CursoId}")]
        public async Task<IActionResult> GetCursoId(int CursoId)
        {
            try
            {
                var results = await _repo.GetCursoId(CursoId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
        }

        //POST api/CursoController
        [HttpPost]
        public async Task<IActionResult> Post(Curso model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync())
                {
                    return Created($"api/Curso/{model.CursoId}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }

        //PUT api/CursoController/5
        [HttpPut("{CursoId}")]
        public async Task<IActionResult> Put(int CursoId, Curso model)
        {
            try
            {
                var results = await _repo.GetCursoId(CursoId);
                if (results == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Curso/{model.CursoId}", model);
                }
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }

        //DELETE api/CursoController/5
        [HttpDelete("{CursoId}")]
        public async Task<IActionResult> Delete(int CursoId)
        {
            try
            {
                var results = await _repo.GetCursoId(CursoId);
                if(results == null)
                {
                    _repo.Delete(results);

                    if(await _repo.SaveChangesAsync())
                    {
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest("Não é Possivel Deletar um curso, pois o mesmo esta vinculado a uma Categoria");
            /* Não é Possivel Excluir um curso, pois o mesmo esta vinculado a uma categoria, e, se deletar a categoria
             * afetara todo o Banco, simplismente posso manter o curso armazenado no Banco de Dados, ou, Alterar o curso;
             * Porem o (DELETE) será mantido, caso Haja uma categoria que seja Única e possa dar um Delete, porém o
             * mais provavel é Alteração ou manutenção do Curso no Banco de Dados*/
        }
    }
}
