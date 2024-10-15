﻿using RestApi.Domain.DTOs;
using RestApi.Domain.Models;

namespace RestApi.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }

        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(b => 
                new EmployeeDTO()
                {
                    Id = b.Id,
                    NameEmployee = b.Name,
                    Photo = b.Photo
                }).ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }



    }
}
