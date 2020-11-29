﻿using EFCoreWebAPI.EFCoreWebAPIDomain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWebAPI.EFCoreWebAPIDomain.Data
{
    public class DataCursoContext  : DbContext
    {
        public DataCursoContext(DbContextOptions<DataCursoContext> options)
            : base(options)
        {
        }

        public DbSet <Aluno> Alunos { get; set; }
        public DbSet <Curso> Cursos { get; set; }
        public DbSet <Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PPP09CP;Database=Curso;User ID=sa;Password=Paradoxo22");
        }
    }
}