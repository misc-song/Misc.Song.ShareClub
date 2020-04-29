using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Misc.Song.ShareClub.DataAccess;
using Misc.Song.ShareClub.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Misc.Song.ShareClub.DAL
{
    public class BaseDal<T> : IBaseDal<T> where T : class, new()
    {
        protected ShareContext dbContext;
        protected DbSet<T> _dbSet;

        public BaseDal(ShareContext context)
        {
            dbContext = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity)
        {
            dbContext.Set<T>().Add(entity);
            bool res = dbContext.SaveChanges() > 0 ? true : false;
            return res;
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            bool res = dbContext.SaveChanges() > 0 ? true : false;
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            var data = dbContext.Set<T>().Where(whereLambda);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        /// <summary>
        /// Get A Entity
        /// </summary>
        /// <param name="whereLambda">select sentence</param>
        /// <returns></returns>
        public T GetEntity(Expression<Func<T, bool>> whereLambda)
        {
            var data = dbContext.Set<T>().Where(whereLambda).FirstOrDefault();
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public IQueryable<T> GetPageEntity(int pageIndex, int PageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, int>> orderByLambda, bool IsAsc)
        {
            var data = dbContext.Set<T>().Where(whereLambda);
            total = data.Count();
            if (IsAsc)
            {
                return data.OrderBy(orderByLambda);
            }
            else
            {
                return data.OrderByDescending(orderByLambda);
            }
        }

        /// <summary>
        ///  Update Or Modify Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>bool</returns>
        public bool ModifyEntity(T entity)
        {
            dbContext.Set<T>().Update(entity);
            bool res = dbContext.SaveChanges() > 0 ? true : false;
            return res;
        }
    }
}
