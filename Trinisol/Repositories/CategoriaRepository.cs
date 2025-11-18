using Trinisol.Data;
using Trinisol.Models;
using Trinisol.Services;

namespace Trinisol.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationDbContext context) : base(context) { }
    }
}
