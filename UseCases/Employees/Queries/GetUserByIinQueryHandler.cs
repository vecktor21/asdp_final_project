using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.UseCases.Employees.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace ASDP.FinalProject.UseCases.Employees.Queries
{
    public class GetEmployeeByIinQueryHandler : IRequestHandler<GetEmployeeByIinQuery, EmployeeDto?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AdspContext _context;

        public GetEmployeeByIinQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _context = unitOfWork.GetContext();

        }
        public async Task<EmployeeDto?> Handle(GetEmployeeByIinQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Iin == request.Iin);

            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
