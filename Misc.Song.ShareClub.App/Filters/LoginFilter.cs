using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Misc.Song.ShareClub.App.Filters
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            try
            {
                var phoneNum = filterContext.HttpContext.Session.GetString("Account");
                var pwd = filterContext.HttpContext.Session.GetString("Password");
                //过滤用户登录
                if (phoneNum == null || pwd == null)
                    filterContext.Result = new RedirectResult("/Login/Index");//未登录重定向到登录页面
            }
            catch
            {
                filterContext.Result = new RedirectResult("/Shared/Error");
            }
        }

        //当方法执行完毕
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}