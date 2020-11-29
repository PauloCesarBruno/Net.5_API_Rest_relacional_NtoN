using EFCoreWebAPI.EFCoreWebAPIDomain.Model;
using System.Threading.Tasks;

namespace EFCoreWebAPI.EFCoreWebAPIRepository
{
    public interface IEFWebApiRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entityRange) where T : class;

        Task<bool> SaveChangesAsync();

        // ==========================================================

        Task<Curso[]> GetCursos();
        Task<Curso> GetCursoId(int CursoId);

        Task<Aluno[]> GetAlunos();
        Task<Aluno> GetAlunoId(int AlunoId);

        Task<Categoria[]> GetCategorias();
        Task<Categoria> GetCategoriaId(int Id);
    }
}
