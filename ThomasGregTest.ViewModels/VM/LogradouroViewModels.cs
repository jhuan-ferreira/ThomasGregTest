using Newtonsoft.Json;
using System.Collections.Generic;

namespace ThomasGregTest.ViewModels.VM
{
    public class LogradouroViewModels
    {
        public LogradouroViewModels()
        {
            ListaLogradouroViewModels = new List<LogradouroViewModels>();
            ClienteViewModels = new ClienteViewModels();
        }
        public int LogradouroId { get; set; }
        public string LogradouroNome { get; set; }
        public int ClienteId { get; set; }

        public ClienteViewModels ClienteViewModels { get; set; }
        [JsonIgnore]
        public List<LogradouroViewModels> ListaLogradouroViewModels { get; set; }


    }
}
