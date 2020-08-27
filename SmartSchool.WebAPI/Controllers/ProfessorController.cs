using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;
        public ProfessorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        //api/professor/id
        [HttpGet("ById")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(professor => professor.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);
        }

        [HttpGet("ByNome")]
        public IActionResult GetByNome(string nome)
        {
            var professor = _context.Professores.Where(professor => professor.Nome.ToLower().Contains(nome.ToLower()));
            if (professor.Count() == 0) return BadRequest("Nenhum professor encontrado");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(professor => professor.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(professor => professor.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(professor => professor.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado");

            _context.Remove(prof);
            _context.SaveChanges();
            return Ok("Professor deletado com sucesso");
        }
    }
}