using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebClient.Models.ViewModels
{
    public class ChangePass
    {
        public string email { get; set; }   

        public string oldPassword { get; set; }

        public string newPassword { get; set; }
    }
}
