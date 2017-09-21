using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVC;

namespace MyWinFormApp
{
    class Item : Model<Item>
    {
        static string Table = "artículos";
        static string[] Columns = { "nombre", "descr", "precio", "cantidad_inicial", "cantidad" };

        static Dictionary<string, string> Connectors
            = new Dictionary<string, string> {
                {"Bill", "id_factura"},
            };

        public BelongsToMany<Bill> bills()
        {
            return this.belongsToMany<Bill>();
        }
    }
}
