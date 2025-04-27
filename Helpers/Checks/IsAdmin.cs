using AizenBankV1.Web.Extensions;
using System.Web;

namespace Helpers.RoleCheck
{
    public static class IsAdmin
    {
        public static bool IsUserAdmin()
        {
            var currentUser = HttpContext.Current.GetMySessionObject();

            if (currentUser.userRoles == Domain.Enums.UserRole.Admin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
