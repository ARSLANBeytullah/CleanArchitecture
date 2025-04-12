using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Employees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Employees
{
    public sealed record EmployeeGetAllQuery() : IRequest<IQueryable<EmployeeGetAllQueryResponse>>;
    public sealed class EmployeeGetAllQueryResponse : EntityDto //Kullanıcıya tablodaki bütün alanları gösterilmeyeceğinden dolayı Response class'ı yazıldı.
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateOnly BirthDate { get; set; }
        public decimal Salary { get; set; }
        public string TCNo { get; set; } = default!;
    }

    internal sealed class GetAllQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<EmployeeGetAllQuery, IQueryable<EmployeeGetAllQueryResponse>>
    {
        public Task<IQueryable<EmployeeGetAllQueryResponse>> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = employeeRepository.GetAll()
                .Select(e => new EmployeeGetAllQueryResponse   //AsQueryable'ı database tarafında yaptığımızdan dolayı burada mapleme yapılamaz. Memory'e çekilip yapılsaydı o zaman mapleme yapılabilirdi.
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                    BirthDate = e.BirthDate,
                    CreateAt = e.CreateAt,
                    DeleteAt = e.DeleteAt,
                    Id = e.Id,
                    IsDeleted = e.IsDeleted,
                    TCNo = e.PersonelInformation.TCNo,
                    UpdateAt = e.UpdateAt,
                })
                .AsQueryable();

            return Task.FromResult(response);
        }
    }
}