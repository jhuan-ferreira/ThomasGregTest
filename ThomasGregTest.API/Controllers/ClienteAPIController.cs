using System.Collections.Generic;
using System.Web.Http;
using ThomasGregTest.Busines.Busines;
using ThomasGregTest.ViewModels.VM;

namespace ThomasGregTest.API.Controllers
{
    public class ClienteAPIController : ApiController
    {
        public ClienteViewModels GetById(int id)
        {
            ClienteBLI clienteBLI = new ClienteBLI();

            return clienteBLI.GetById(id);
        }

        [Authorize]
        public List<ClienteViewModels> GetAll()
        {
            ClienteBLI clienteBLI = new ClienteBLI();

            return clienteBLI.GetAll();
        }

        public void Post([FromBody] ClienteViewModels clienteViewModels)
        {
            ClienteBLI clienteBLI = new ClienteBLI();

            clienteBLI.Save(clienteViewModels);
        }

        public void Delete(int id)
        {
            ClienteBLI clienteBLI = new ClienteBLI();
            var clienteViewModels = clienteBLI.GetById(id);
            clienteBLI.Delete(clienteViewModels);
        }
    }
}
