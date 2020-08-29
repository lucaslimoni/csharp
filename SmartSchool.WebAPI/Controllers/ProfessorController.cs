using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IMapper _mapper;

        public readonly IRepository _repo;
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var prof = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(prof));
        }

        //api/professor/id
        [HttpGet("ById")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, true);
            if (professor == null) return BadRequest("Professor não encontrado");
            var professorDto = _mapper.Map<ProfessorDto>(professor);

            return Ok(professorDto);
        }

        [HttpGet("ByNome")]
        public IActionResult GetByNome(string nome)
        {
            var professor = _repo.GetProfessorByNome(nome, true);
            if (professor.Count() == 0) return BadRequest("Nenhum professor encontrado");

            var professorDto = _mapper.Map<IEnumerable<ProfessorDto>>(professor);

            return Ok(professorDto);
        }

        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado");

            _mapper.Map(model, professor);
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não alterado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado");

            _mapper.Map(model, professor);
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não alterado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id, true);
            if (prof == null) return BadRequest("Professor não encontrado");

            _repo.Delete(prof);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado com sucesso");
            }
            return BadRequest("Professor não deletado");
        }
    }
}