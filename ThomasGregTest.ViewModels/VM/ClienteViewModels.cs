using System.Collections.Generic;

namespace ThomasGregTest.ViewModels.VM
{
    public class ClienteViewModels
    {
        public ClienteViewModels()
        {
            ListaClienteViewModels = new List<ClienteViewModels>();
        }
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<ClienteViewModels> ListaClienteViewModels { get; set; }
    }
}
