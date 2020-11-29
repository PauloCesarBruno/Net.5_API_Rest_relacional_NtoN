using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreWebAPI.EFCoreWebAPIDomain.Model
{
    public class Categoria
    {
        public Categoria()
        {
            this.Cursos = new List<Curso>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Curso Categoria")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Entre 03 e 100 Caracteres")]
        public String CursoCategoria { get; set; }

        public virtual ICollection <Curso> Cursos { get; set; }
    }
}
