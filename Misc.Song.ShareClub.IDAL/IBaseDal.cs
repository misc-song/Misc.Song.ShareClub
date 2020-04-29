using System;
using System.Linq;

namespace Misc.Song.ShareClub.IDAL
{
    public interface IBaseDal<T> where T : class, new()
    {
        bool AddEntity(T entity);
        bool DeleteEntity(T entity);
        bool ModifyEntity(T entity);
        T GetEntity(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetPageEntity(int pageIndex, int PageSize, out int total, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, int>> orderByLambda, bool IsAsc);
    }
}
