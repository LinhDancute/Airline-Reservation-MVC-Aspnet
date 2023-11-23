using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace App.Areas.Staff
{
    public class AddStaffRoleModel
  {
    public App.Models.Staff.Staff staff { get; set; }

    [DisplayName("Các role gán cho user")]
    public string[] RoleNames { get; set; }

    public List<IdentityRoleClaim<string>> claimsInRole { get; set; }
    public List<IdentityUserClaim<string>> claimsInUserClaim { get; set; }

  }
}