using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.common
{
    interface Irepository<T>
    {
        T Add(T t);
        T Get(T t);
        IEnumerable<T> Find(T t);
    }
}
