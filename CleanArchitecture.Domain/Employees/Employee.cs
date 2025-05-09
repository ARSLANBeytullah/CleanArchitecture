﻿using CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Employees
{
    public sealed class Employee : Entity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string FullName => string.Join(" ", FirstName, LastName);
        public DateOnly BirthDate { get; set; }
        public decimal Salary { get; set; }
        public PersonelInformation PersonelInformation { get; set; } = default!;
        public Address? Address { get; set; } = default!;
    }
}
