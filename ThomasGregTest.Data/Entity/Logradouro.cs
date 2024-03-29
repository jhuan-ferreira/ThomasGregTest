
namespace ThomasGregTest.Data.Entity
{
    public class Logradouro
    {
        public int LogradouroId { get; set; }
        public string LogradouroNome { get; set; }
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
