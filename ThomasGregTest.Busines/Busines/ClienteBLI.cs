using Omu.ValueInjecter;
using System.Collections.Generic;
using ThomasGregTest.Data.Entity;
using ThomasGregTest.Data.Infraestruture;
using ThomasGregTest.ViewModels.VM;

namespace ThomasGregTest.Busines.Busines
{
    public class ClienteBLI
    {
        public bool Save(ClienteViewModels clienteViewModels)
        {
            using (var _db = new SqlUnityOfWork())
            {
                var cliente = new Cliente();
                cliente.InjectFrom(clienteViewModels);
                cliente = _db.ClienteRepository.Save(cliente);

                if (cliente.ClienteId != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Delete(ClienteViewModels clienteViewModels)
        {
            using (var _db = new SqlUnityOfWork())
            {
                var cliente = new Cliente();
                cliente.InjectFrom(clienteViewModels);
                return _db.ClienteRepository.Delete(cliente);
            }
        }

        public List<ClienteViewModels> GetAll()
        {
            using (var _db = new SqlUnityOfWork())
            {
                var listaClienteViewModels = new List<ClienteViewModels>();

                var cliente = _db.ClienteRepository.GetAll();

                foreach (var item in cliente)
                {
                    var clienteViewModels = new ClienteViewModels();
                    clienteViewModels.InjectFrom(item);

                    listaClienteViewModels.Add(clienteViewModels);
                }

                return listaClienteViewModels;
            }
        }

        public ClienteViewModels GetById(int id)
        {
            using (var _db = new SqlUnityOfWork())
            {
                var cliente = _db.ClienteRepository.GetById(id);

                var clienteViewModels = new ClienteViewModels();
                clienteViewModels.InjectFrom(cliente);

                return clienteViewModels;
            }
        }
    }
}
