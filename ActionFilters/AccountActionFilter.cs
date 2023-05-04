﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication2.Models;

namespace WebApplication2.ActionFilters
{
    public class AccountActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string accessToken = context.HttpContext.Request.Cookies["user-access-token"];
            HospitalContext _context = context.HttpContext.RequestServices.GetRequiredService<HospitalContext>();
            User user = _context.Users.Where(x => x.AccessToken == accessToken).FirstOrDefault();

            if (user is not null)
            {
                context.Result = new RedirectResult("/Home/Index");
            }
        }
    }
}
