using HasherMarketPlace.ModelHelper.Models;
using System.ComponentModel.DataAnnotations;

namespace HasherMarketPlace.ModelHelper.Helper
{
    public class UserRoleAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var role = value.ToString();
            return role.Equals(Roles.Admin.ToString().ToLower()) || role.ToLower().Equals(Roles.User.ToString().ToLower());
        }
    }
}
