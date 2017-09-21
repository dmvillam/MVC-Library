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
        static string Table = "clientes";
        static string[] Columns = { "nombre", "correo", "telf1", "cel" };

        public List<Bill> bills()
        {
            return this.hasMany<Bill>("id_cliente");
        }
    }
}
