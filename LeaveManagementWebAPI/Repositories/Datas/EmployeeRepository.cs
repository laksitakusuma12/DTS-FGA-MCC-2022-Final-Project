﻿using System;
using System.Collections.Generic;
using System.Linq;
using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Repositories.Interfaces;
using LeaveManagementWebAPI.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementWebAPI.Repositories.Datas
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DBContext _dbContext;

        public EmployeeRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetData()
        {
            return _dbContext.Employees
                .Include(model => model.genderType)
                .Include(model => model.departmentType)
                .ToList();
        }

        public Employee GetData(int id)
        {
            return _dbContext.Employees
                .Include(model => model.genderType)
                .Include(model => model.departmentType)
                .FirstOrDefault(model => model.id == id);
        }

        public int EditData(EmployeeViewModel employeeViewModel)
        {
            int result = 0;
            var data = GetData(employeeViewModel.id);

            if (data != null)
            {
                data.firstName = employeeViewModel.firstName;
                data.lastName = employeeViewModel.lastName;
                data.genderTypeId = employeeViewModel.genderTypeId;
                data.email = employeeViewModel.email;
                data.phoneNumber = employeeViewModel.phoneNumber;
                data.departmentTypeId = employeeViewModel.departmentTypeId;
                data.managerId = employeeViewModel.managerId;
                data.updatedAt = DateTime.Now;

                _dbContext.Employees.Update(data);
                result = _dbContext.SaveChanges();

                return result;

            }

            return result;
        }

        public int CreateData(EmployeeViewModel employeeViewModel)
        {
            _dbContext.Employees.Add(new Employee
            {
                firstName = employeeViewModel.firstName,
                lastName = employeeViewModel.lastName,
                genderTypeId = employeeViewModel.genderTypeId,
                email = employeeViewModel.email,
                phoneNumber = employeeViewModel.phoneNumber,
                departmentTypeId = employeeViewModel.departmentTypeId,
                managerId = employeeViewModel.managerId,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            });
            var result = _dbContext.SaveChanges();

            return result;
        }

        public int DeleteData(int id)
        {
            var data = GetData(id);

            _dbContext.Employees.Remove(data);
            var result = _dbContext.SaveChanges();
            
            return result;
        }
    }
}
