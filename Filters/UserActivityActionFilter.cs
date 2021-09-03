using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UserActivityLog.Data;
using UserActivityLog.Models;

namespace UserActivityLog.Filters
{
    public class UserActivityActionFilter:IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Random rnd = new Random();
            int randomUser = rnd.Next(1, 13);

            var user = context.HttpContext.User.Claims;
            var remoteIP = context.HttpContext.Connection.RemoteIpAddress;
            var localIP = context.HttpContext.Connection.LocalIpAddress;
            //Get Your Page Information
            var request = context.HttpContext.Request;
            var currentUser = context.HttpContext.User.Identity.Name;
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
            var httpVerb = context.HttpContext.Request.Method;

            //Database Operation Context
            var _dbContext = context.HttpContext.RequestServices.GetRequiredService<UserActivityLogContext>();
            var userLog = new UserLog();
            userLog.user_id = randomUser;
            userLog.user_name = "User :" + randomUser;
            userLog.login_date = DateTime.Now;
            userLog.login_time = DateTime.Now.ToString("HH:mm:ss tt");
            userLog.ip_address = localIP.ToString();
            userLog.page_name = action;
            userLog.controller = controller;
            userLog.http_verb = httpVerb;
            //Save the context
            _dbContext.UserLog.Add(userLog);
            _dbContext.SaveChanges();
            Debug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Random rnd = new Random();
            int randomUser = rnd.Next(1, 13);
            var user = context.HttpContext.User.Claims;
            var remoteIP = context.HttpContext.Connection.RemoteIpAddress;
            var localIP = context.HttpContext.Connection.LocalIpAddress;
            //Get Your Page Information
            var request = context.HttpContext.Request;
            var currentUser = context.HttpContext.User.Identity.Name;
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
            var httpVerb = context.HttpContext.Request.Method;

            //Database Operation Context
            var _dbContext = context.HttpContext.RequestServices.GetRequiredService<UserActivityLogContext>();
            var userLog = new UserLog();
            userLog.user_id = randomUser;
            userLog.user_name = "User :" + randomUser;
            userLog.login_date = DateTime.Now;
            userLog.login_time = DateTime.Now.ToString("HH:mm:ss tt");
            userLog.ip_address = localIP.ToString();
            userLog.page_name = action;
            userLog.controller = controller;
            userLog.http_verb = httpVerb;
            //Save the context
            _dbContext.UserLog.Add(userLog);
            _dbContext.SaveChanges();

            Debug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }
    }
}
