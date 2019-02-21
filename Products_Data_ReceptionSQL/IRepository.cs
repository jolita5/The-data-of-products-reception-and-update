using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Data_ReceptionSQL
{
    public interface IRepository<T>
    {
        T Get(int id);
        List<T> GetAll();
        void Update(T item);
        void Add(T item);
        void Delete(int id);
    }
}
