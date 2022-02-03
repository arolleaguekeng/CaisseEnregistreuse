using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.common
{
    public interface IRepository<T>
    {
        T Add(T t);
        T Get(T t);
        IEnumerable<T> Find(T t);
    }
}
