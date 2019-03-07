using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ContextContest _context;

        public Repository(ContextContest context)
        {
            this._context = context;
        }
        public void Commit()
        {
            this._context.SaveChanges();
        }

        public void Create(T item)
        {
            this._context.Set<T>().Add(item);
        }

        public void Delete(int? id)
        {
            this._context.Set<T>().Remove(this.Get(id));
        }

        public void Dispose()
        {
           this._context.Dispose();
        }

        public T Get(int? id)
        {
           return this._context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return this.GetAll(x => true);
        }

        public List<T> GetAll(Func<T, bool> filter)
        {
            return this._context.Set<T>().Where(filter).ToList();
        }
    }
}
