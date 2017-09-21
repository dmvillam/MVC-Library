using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    public class Collection<T> : List<T>
        where T : Model<T>
    {
        public T first()
        {
            return (this.Count > 0) ? this[0] : null;
        }

        public T last()
        {
            return (this.Count > 0) ? this[this.Count - 1] : null;
        }

        public Collection<T> get()
        {
            return this;
        }
    }
}
