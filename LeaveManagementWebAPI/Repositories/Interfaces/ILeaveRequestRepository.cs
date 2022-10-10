using System.Collections.Generic;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface ILeaveRequestRepository
    {
        LeaveRequest GetData(int id);

        List<LeaveRequest> GetDataByManager(int managerId, int departmentTypeId);

        List<LeaveRequest> GetDataByEmployee(int userId);

        int EditData(LeaveRequestViewModel leaveRequestViewModel);

        int CreateData(LeaveRequestViewModel leaveRequestViewModel);
        
        int DeleteData(int id);
    }
}
