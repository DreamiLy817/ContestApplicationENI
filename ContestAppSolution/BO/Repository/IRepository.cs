using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        /// 
        /// </summary>
        /// <param name="filter">Filtre à appliquer avant de faire un .ToList()</param>
        /// <returns></returns>
        List<T> GetAll(Func<T, bool> filter);

        List<T> GetAll();

        T Get(int? id);

        void Create(T item);

        void Commit();

        void Delete(int? id);
    }
}
