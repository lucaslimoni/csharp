namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }
        public AlunoDisciplina(int alunoid, int disciplinaId)
        {
            this.Alunoid = alunoid;
            this.DisciplinaId = disciplinaId;
        }
        public int Alunoid { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}