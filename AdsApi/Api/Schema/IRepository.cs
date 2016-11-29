using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdsApi.Api.Schema
{
    public interface IRepository
    {
        IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
        void Add<T>(T obj) where T : class;
        void Delete<T>(T obj) where T : class;
        void Save();
        void Dispose();
    }
}
