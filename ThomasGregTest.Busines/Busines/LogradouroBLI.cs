using System.Collections.Generic;
using ThomasGregTest.Data.Entity;
using ThomasGregTest.Data.Infraestruture;
using ThomasGregTest.ViewModels.VM;
using Omu.ValueInjecter;

namespace ThomasGregTest.Busines.Busines
{
    public class LogradouroBLI
    {
        public bool Save(LogradouroViewModels logradouroViewModels)
        {
            using (var _db = new SqlUnityOfWork())
            {
                var logradouro = new Logradouro();
                logradouro.InjectFrom(logradouroViewModels);
                logradouro = _db.LogradouroRepository.Save(logradouro);

                if (logradouro.LogradouroId != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Delete(LogradouroViewModels logradouroViewModels)
        {
            using (var _db = new SqlUnityOfWork())
            {
                var logradouro = new Logradouro();
                logradouro.InjectFrom(logradouroViewModels);
                return _db.LogradouroRepository.Delete(logradouro);
            }
        }

        public List<LogradouroViewModels> GetAll()
        {
            using (var _db = new SqlUnityOfWork())
            {
                var listaLogradouroViewModels = new List<LogradouroViewModels>();

                var logradouro = _db.LogradouroRepository.GetAll();

                foreach (var item in logradouro)
                {
                    var logradouroViewModels = new LogradouroViewModels();
                    logradouroViewModels.InjectFrom(item);
                    logradouroViewModels.ClienteViewModels.InjectFrom(item.Cliente);

                    listaLogradouroViewModels.Add(logradouroViewModels);
                }

                return listaLogradouroViewModels;
            }
        }

        public LogradouroViewModels GetById(int id)
        {
            using (var _db = new SqlUnityOfWork())
            {
                var logradouro = _db.LogradouroRepository.GetById(id);

                var logradouroViewModels = new LogradouroViewModels();
                var _listaLogradouroViewModels = GetAll();

                logradouroViewModels.InjectFrom(logradouro);
                
                foreach (var item in _listaLogradouroViewModels)
                {
                    logradouroViewModels.InjectFrom(item);
                    logradouroViewModels.ListaLogradouroViewModels.Add(logradouroViewModels);
                }

                return logradouroViewModels;
            }
        }
    }
}
