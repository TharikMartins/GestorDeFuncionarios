using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Infraestructure.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        List<T> List();
        void Save(T Entity);
        void Delete(T Entity);
        T FindById(int Id);
        void Update(T Entity);


    }
}
