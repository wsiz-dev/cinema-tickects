using System.Collections.Generic;
using System.Security.Claims;
using CinemaTickets.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CinemaTickets.UI
{
    public static class AspNetExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole("Admin");

        public static void PopulateValidation(this ModelStateDictionary modelState, IEnumerable<Result.Error> errors) 
        {
            foreach (var error in errors)
            {
                modelState.AddModelError(error.PropertyName, error.Message);
            }
        }
    }
}
