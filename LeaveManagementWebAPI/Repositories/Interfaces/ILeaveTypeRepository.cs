using System.Collections.Generic;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface ILeaveTypeRepository
    {
        List<LeaveType> GetData();

        LeaveType GetData(int id);

        List<LeaveType> GetDataByGender(int genderId);

        int EditData(LeaveTypeViewModel leaveTypeViewModel);

        int CreateData(LeaveTypeViewModel leaveTypeViewModel);
        
        int DeleteData(int id);
    }
}
