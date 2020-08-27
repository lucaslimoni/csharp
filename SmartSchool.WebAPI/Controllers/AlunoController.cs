using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using System.Linq;
using SmartSchool.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        //api/aluno/id
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpGet("byNome")]
        public IActionResult GetByName(string nome)
        {
            if (nome == null) return BadRequest("Nome não pode ser nulo para busca");
            var aluno = _repo.GetAlunosByNome(nome, true);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpGet("byNomeSobrenome")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            if (nome == null) return BadRequest("Nome não pode ser nulo para busca");
            if (sobrenome == null) return BadRequest("Sobrenome não pode ser nulo para busca");
            var aluno = _repo.GetAlunosByNomeSobrenome(nome, sobrenome, true);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }


        //api/aluno/nome
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado");
        }

        //api/aluno/nome
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var al = _repo.GetAlunoById(id);
            if (al == null) return BadRequest("Aluno não encontrado");
            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não atualizado");
        }

        //api/aluno/nome
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var al = _repo.GetAlunoById(id);
            if (al == null) return BadRequest("Aluno não encontrado");
            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não atualizado");
        }

        //api/aluno/nome
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno deletado com sucesso");
            }
            return BadRequest("Aluno não deletado");
        }
    }
}