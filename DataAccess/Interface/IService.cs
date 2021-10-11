using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IService<T>
    {
        void Delete(int _id);
        IEnumerable<T> GetAll();
        T GetById(int _id);
        void Insert(T _obj);
        void Update(T _obj);
    }
}
