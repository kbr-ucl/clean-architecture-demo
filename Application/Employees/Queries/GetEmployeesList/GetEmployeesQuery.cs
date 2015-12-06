﻿using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery 
        : IGetEmployeesListQuery
    {
        private readonly IDatabaseContext _database;

        public GetEmployeesListQuery(IDatabaseContext database)
        {
            _database = database;
        }

        public List<EmployeeModel> Execute()
        {
            var employees = _database.Employees
                .Select(p => new EmployeeModel
                {
                    Id = p.Id,
                    Name = p.Name
                });               

            return employees.ToList();
        }
    }

    public interface IGetEmployeesListQuery
    {
        List<EmployeeModel> Execute();
    }
}