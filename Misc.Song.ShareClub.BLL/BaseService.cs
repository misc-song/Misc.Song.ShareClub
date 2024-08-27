using Misc.Song.ShareClub.IBLL;
using Misc.Song.ShareClub.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misc.Song.ShareClub.BLL
{
    public class BaseService<T> :IBaseService<T> where T : class, new()
    {
        public IBaseDal<T> baseDal { get; set; }
        public BaseService(IBaseDal<T> dal)
        {
            this.baseDal = dal;
        }
        /// <summary>
        /// 增加一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity)
        {
            return baseDal.AddEntity(entity);
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            return baseDal.DeleteEntity(entity);
        }
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool ModifyEntity(T entity)
        {
            return baseDal.ModifyEntity(entity);
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T GetEntity(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return baseDal.GetEntity(whereLambda);
        }
        /// <summary>
        /// 获取多个实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return baseDal.GetEntities(whereLambda);
        }
        /// <summary>
        /// 分页获取实体
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="IsAsc"></param>
        /// <returns></returns>
        public IQueryable<T> GetPageEntity(int pageIndex, int PageSize, out int total, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, int>> orderByLambda, bool IsAsc)
        {
            return baseDal.GetPageEntity(pageIndex, PageSize, out total, whereLambda, orderByLambda, IsAsc);
        }

     
    }
}
