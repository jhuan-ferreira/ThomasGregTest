using System;
using ThomasGregTest.Data.IRepository;
using ThomasGregTest.Data.Repository;

namespace ThomasGregTest.Data.Infraestruture
{
    public class SqlUnityOfWork : IDisposable
    {
        private readonly ThomasGregTestContext dbContext = new ThomasGregTestContext();

        #region Interface Repository

        private IClienteRepository _clienteRepository;
        private ILogradouroRepository _logradouroRepository;

        #endregion

        #region Construtor Repository

        public IClienteRepository ClienteRepository {  get { return _clienteRepository ?? (_clienteRepository = new ClienteRespository(dbContext)); } }
        public ILogradouroRepository LogradouroRepository {  get { return _logradouroRepository ?? (_logradouroRepository = new LogradouroRepository(dbContext)); } }

        #endregion

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed) 
            {
                if (disposing) 
                {
                    dbContext.Dispose();
                }
            }

            _disposed = true;
        }


        #region Dispose Repository

        public void Dispose()
        {
            if (_clienteRepository != null) { _clienteRepository.Dispose(); _clienteRepository = null; }
            if (_logradouroRepository != null) { _logradouroRepository.Dispose(); _logradouroRepository = null; }
            
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
