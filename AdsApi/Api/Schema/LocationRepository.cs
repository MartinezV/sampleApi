using AdsApi.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AdsApi.Api.Schema
{
    public class LocationRepository : IRepository
    {
        private LocationEntities _db = new LocationEntities();
        //Finding Records
        public IQueryable<T> Query<T>(params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties) where T : class
        {
            var query = _db.Set<T>().AsQueryable();
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);
            return query;
        }
        //Adding Records
        public void Add<T>(T obj) where T : class
        {
            _db.Set<T>().Add(obj);
        }

        //Deleteing Records
        public void Delete<T>(T obj) where T : class
        {
            _db.Set<T>().Remove(obj);
        }

        //Save Records
        public void Save()
        {
            _db.SaveChanges();
        }

        //Dispose
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}