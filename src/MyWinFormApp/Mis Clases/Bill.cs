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
        public override string table { get { return "facturas"; } }
        public override string[] columns { get { return new string[] { "notas", /*"fecha inicio", "fecha vencimiento",*/ "id_cliente" }; } }

        public Client client()
        {
            return this.belongsTo<Client>("id_cliente");
        }

        public List<Item> items()
        {
            var connector = new Dictionary<string, string> {
                {"Bill", "id_factura"},
                {"Item", "id_artículo"}
            };
            return this.hasMany<Item>(connector, "facturas_artículos");
        }
    }
}
