
using System.Collections.Generic;

namespace ThomasGregTest.Data.Entity
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Logradouro> Logradouros { get; set; }
    }
}
