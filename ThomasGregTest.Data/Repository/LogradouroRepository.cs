using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ThomasGregTest.Data.Entity;
using ThomasGregTest.Data.Infraestruture;
using ThomasGregTest.Data.IRepository;

namespace ThomasGregTest.Data.Repository
{
    public class LogradouroRepository : RepositoryBase<Logradouro>, ILogradouroRepository
    {
        public LogradouroRepository(DbContext dbContext) : base(dbContext)
        {
            
        }

        public new List<Logradouro> GetAll()
        {
            return DbSet
                .AsNoTracking()
                .Include(x => x.Cliente)
                .ToList();
        }
    }
}
