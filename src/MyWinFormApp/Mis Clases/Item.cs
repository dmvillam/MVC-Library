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

        public List<Bill> bills()
        {
            var connector = new Dictionary<string,string> {
                {"Bill", "id_factura"},
                {"Item", "id_artículo"}
            };
            return this.belongsToMany<Bill>(connector, "facturas_artículos");
        }
    }
}
