using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Employees
{
    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string FullName => string.Join(" ", FirstName, LastName);
        public DateOnly BirthDate { get; set; }
        public decimal Salary { get; set; }
    }


    //Database tarafında bir tablo olarak tutulmayacak o yüzden record olarak tanımladım.
    //Value Object
    public sealed record PersonelInformation
    {
        public string? TCNo { get; set; }
        public string? Email { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
    }

    //Value Object
    public sealed record Address
    {
        
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Town { get; set; }
        public string? FullAddress { get; set; }
    }
}
