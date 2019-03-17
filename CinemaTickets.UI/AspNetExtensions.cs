using System.Security.Claims;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CinemaTickets.UI
{
    public static class AspNetExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole("Admin");

        public static void PopulateValidation(this ModelStateDictionary modelState, ValidationResult validationResult) 
        {
            foreach (var error in validationResult.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
