using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVC;

namespace MyWinFormApp
{
    class Bill : Model<Bill>
    {
        static string Table = "facturas";
        static string[] Columns = { "notas", /*"fecha inicio", "fecha vencimiento",*/ "id_cliente" };

        static Dictionary<string, string> Connectors
            = new Dictionary<string, string> {
                {"Client", "id_cliente"},
                {"Item", "id_artículo"},
            };

        public Client client()
        {
            return this.belongsTo<Client>();
        }

        public BelongsToMany<Item> items()
        {
            return this.belongsToMany<Item>();
        }
    }
}
