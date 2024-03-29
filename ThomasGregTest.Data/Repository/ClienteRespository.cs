using System.Data.Entity;
using ThomasGregTest.Data.Entity;
using ThomasGregTest.Data.Infraestruture;
using ThomasGregTest.Data.IRepository;

namespace ThomasGregTest.Data.Repository
{
    public class ClienteRespository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRespository(DbContext dbContext) : base(dbContext) 
        {
            
        }
    }
}
