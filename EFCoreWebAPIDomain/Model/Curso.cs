using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreWebAPI.EFCoreWebAPIDomain.Model
{
    public class Curso
    {
        public Curso()
        {
            this.Alunos = new List<Aluno>();
        }

        public int CursoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Curso Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Entre 03 e 100 Caracteres")]
        public String CursoNome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public Decimal?  Valor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection <Aluno> Alunos { get; set; }
    }
}
