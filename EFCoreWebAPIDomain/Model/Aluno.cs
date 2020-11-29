using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreWebAPI.EFCoreWebAPIDomain.Model
{
    public class Aluno
    {
        public Aluno()
        {
            this.Cursos = new List<Curso>();
        }

        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Entre 03 e 100 Caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Telefone")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Minimo 8 Caracteres")]
        public String Telefone { get; set; }

        public virtual ICollection <Curso> Cursos { get; set; }
    }
}
