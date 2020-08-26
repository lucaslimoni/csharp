using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using System.Linq;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id =1,
                Nome = "Marcos",
                Sobrenome = "Paulo",
                Telefone = "41999999999"
            },
            new Aluno(){
                Id =2,
                Nome = "Pedro",
                Sobrenome = "Lucas",
                Telefone = "41999999998"
            },
            new Aluno(){
                Id =3,
                Nome = "José",
                Sobrenome = "Aparecido",
                Telefone = "41999999997"
            },
            new Aluno(){
                Id = 4,
                Nome = "Marcos",
                Sobrenome = "Vinicius",
                Telefone = "41999999996"
            },
        };
        public AlunoController() { }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        //api/aluno/id
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(aluno => aluno.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpGet("byNome")]
        public IActionResult GetByName(string nome)
        {
            if (nome == null) return BadRequest("Nome não pode ser nulo para busca");
            var aluno = Alunos.FindAll(aluno => aluno.Nome.ToLower().Contains(nome.ToLower()));
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpGet("byNomeSobrenome")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            if (nome == null) return BadRequest("Nome não pode ser nulo para busca");
            if (sobrenome == null) return BadRequest("Sobrenome não pode ser nulo para busca");
            var aluno = Alunos.FindAll(aluno => aluno.Nome.ToLower().Contains(nome.ToLower())
            && aluno.Sobrenome.ToLower().Contains(sobrenome.ToLower()));
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }


        //api/aluno/nome
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno/nome
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Aluno deletado com sucesso");
        }
    }
}