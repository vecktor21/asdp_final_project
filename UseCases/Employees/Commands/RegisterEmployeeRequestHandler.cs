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
            var position = await _context.Positions.SingleAsync(x => x.Code == request.PositionCode);

            Employee employee = new Employee(request.Name, request.SurName, request.Iin, request.Mail, request.IdentityNumber,
                request.IdentityIssuer, request.IdentityIssueDate, position);
            
            _context.Employees.Add(employee);
            await _unitOfWork.SaveChangesAsync();
            
            var dto = _mapper.Map<EmployeeDto>(employee);
            
            return dto;
        }
    }
}
