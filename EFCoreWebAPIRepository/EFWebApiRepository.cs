using EFCoreWebAPI.EFCoreWebAPIDomain.Data;
using EFCoreWebAPI.EFCoreWebAPIDomain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWebAPI.EFCoreWebAPIRepository
{
    public class EFWebApiRepository : IEFWebApiRepository
    {
        private readonly DataCursoContext _context;

        public EFWebApiRepository(DataCursoContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // ============================================================================

        public Task<Curso[]> GetCursos()
        {
            IQueryable<Curso> query = _context.Cursos
                .Include(a => a.Alunos)
                .Include(ca => ca.Categoria);

            query = query.AsNoTracking()
            .OrderBy(c => c.CursoNome);

            return query.ToArrayAsync();
        }

        public Task<Curso> GetCursoId(int CursoId)
        {
            IQueryable<Curso> query = _context.Cursos
               .Include(a => a.Alunos)
               .Include(ca => ca.Categoria);

            query = query.AsNoTracking()
                .OrderByDescending(c => c.CursoNome)
                .Where(c => c.CursoId == CursoId); 

            return query.FirstOrDefaultAsync();
        }

        public Task<Aluno[]> GetAlunos()
        {
            IQueryable<Aluno> query = _context.Alunos;

            query = query.AsNoTracking()
                .OrderBy(a => a.Nome);

            return query.ToArrayAsync();
        }

        public Task<Aluno> GetAlunoId(int AlunoId)
        {
            IQueryable<Aluno> query = _context.Alunos;

            query = query.AsNoTracking()
                .OrderByDescending(a => a.Nome)
                .Where(a => a.AlunoId == AlunoId);

            return query.FirstOrDefaultAsync();
        }

        public Task<Categoria[]> GetCategorias()
        {
            IQueryable<Categoria> query = _context.Categorias;

            query = query.AsNoTracking()
                .OrderBy(ca=> ca.Id);

            return query.ToArrayAsync();
        }

        public Task<Categoria> GetCategoriaId(int Id)
        {
            IQueryable<Categoria> query = _context.Categorias;

            query = query.AsNoTracking()
                .OrderByDescending(ca => ca.Id)
                .Where(ca => ca.Id == Id);

            return query.FirstOrDefaultAsync();
        }
    }
}