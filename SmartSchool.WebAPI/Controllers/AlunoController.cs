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
        private readonly DataContext _context;

        public AlunoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        //api/aluno/id
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpGet("byNome")]
        public IActionResult GetByName(string nome)
        {
            if (nome == null) return BadRequest("Nome não pode ser nulo para busca");
            var aluno = _context.Alunos.Where(aluno => aluno.Nome.ToLower().Contains(nome.ToLower()));
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpGet("byNomeSobrenome")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            if (nome == null) return BadRequest("Nome não pode ser nulo para busca");
            if (sobrenome == null) return BadRequest("Sobrenome não pode ser nulo para busca");
            var aluno = _context.Alunos.Where(aluno => aluno.Nome.ToLower().Contains(nome.ToLower())
            && aluno.Sobrenome.ToLower().Contains(sobrenome.ToLower()));
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }


        //api/aluno/nome
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var al = _context.Alunos.AsNoTracking().FirstOrDefault(aluno => aluno.Id == id);
            if (al == null) return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var al = _context.Alunos.AsNoTracking().FirstOrDefault(aluno => aluno.Id == id);
            if (al == null) return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok("Aluno deletado com sucesso");
        }
    }
}