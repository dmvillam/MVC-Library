using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVC;

namespace MyWinFormApp
{
    class Client : Model<Client>
    {
        public override string table { get { return "clientes"; } }
        public override string[] columns { get { return new string[] { "nombre", "correo", "telf1", "cel" }; } }

        public List<Bill> bills()
        {
            return this.hasMany<Bill>("id_cliente");
        }
    }
}
