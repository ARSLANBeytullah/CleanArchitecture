using CleanArchitecture.Application.Employees;
using CleanArchitecture.Domain.Employees;
using FluentValidation;
using GenericRepository;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace CleanArchitecture.Application.Employees;

public sealed record EmployeeCreateCommand
    (string FirstName,
     string LastName,
     DateOnly BirthOfDate,
     decimal Salary,
     PersonelInformation PersonelInformation,
     Address? Address) : IRequest<Result<string>>;

public sealed class EmployeeCreateCommandValidator : AbstractValidator<EmployeeCreateCommand>
{
    public EmployeeCreateCommandValidator()
    {
        RuleFor(e => e.FirstName).MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır");
        RuleFor(e => e.LastName).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter olmalıdır");
        RuleFor(e => e.PersonelInformation.TCNo).MinimumLength(11).WithMessage("Geçerli bir TC Numarası yazın.")
                                                .MaximumLength(11).WithMessage("Geçerli bir TC Numarası yazın.");


    }
}


internal sealed class EmployeeCreateCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<EmployeeCreateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
    {
        var isEmployeeExist = await employeeRepository
            .AnyAsync(e => e.PersonelInformation.TCNo == request.PersonelInformation.TCNo, cancellationToken);

        if (isEmployeeExist)
        {
            return Result<string>.Failure("Bu TC numarası daha önce kaydedilmiş");
        }

        Employee employee = request.Adapt<Employee>(); //Mapster ile map'ledim.

        employeeRepository.Add(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Personel kaydı başarıyla tamamlandı";
    }
}

