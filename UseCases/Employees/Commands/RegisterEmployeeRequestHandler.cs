using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Helpers;
using ASDP.FinalProject.UseCases.Employees.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Employees.Commands
{
    public class RegisterEmployeeRequestHandler : IRequestHandler<RegisterEmployeeRequest, EmployeeDto>
    {
        private readonly AdspContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterEmployeeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = unitOfWork.GetContext();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Handle(RegisterEmployeeRequest request, CancellationToken cancellationToken)
        {
            var hashPassword = PasswordHasher.HashPassword(request.Password);
            Employee emp = _mapper.Map<Employee>(request);
            emp.Password = hashPassword;

            var position = await _context.Positions.SingleAsync(x => x.Code == request.PositionCode);
            emp.Position = position;
            _context.Employees.Add(emp);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<EmployeeDto>(emp);
            return dto;
        }
    }
}
