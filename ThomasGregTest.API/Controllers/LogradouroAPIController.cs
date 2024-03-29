using System.Collections.Generic;
using System.Web.Http;
using ThomasGregTest.Busines.Busines;
using ThomasGregTest.ViewModels.VM;

namespace ThomasGregTest.API.Controllers
{
    public class LogradouroAPIController : ApiController
    {
        public LogradouroViewModels GetById(int id)
        {
            LogradouroBLI logradouroBLI = new LogradouroBLI();

            return logradouroBLI.GetById(id);
        }

        [Authorize]
        public List<LogradouroViewModels> GetAll()
        {
            LogradouroBLI logradouroBLI = new LogradouroBLI();

            return logradouroBLI.GetAll();
        }

        public void Post([FromBody] LogradouroViewModels logradouroViewModels)
        {
            LogradouroBLI logradouroBLI = new LogradouroBLI();

            logradouroBLI.Save(logradouroViewModels);
        }

        public void Delete(int id)
        {
            LogradouroBLI logradouroBLI = new LogradouroBLI();
            var logradouroViewModels = logradouroBLI.GetById(id);
            logradouroBLI.Delete(logradouroViewModels);
        }
    }
}