using System.Collections.Generic;

namespace SeriesRegistration.app.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();

        T ReturnPerId(int id);

        void Insert(T entity);

        void Exclude(int id);

        void Att(int id, T entity);

        int NextId();
    }
}