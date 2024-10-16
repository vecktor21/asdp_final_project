using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.DAL;
using ASDP.FinalProject.UseCases.Employees.Dtos;
using MediatR;
using ASDP.FinalProject.Constants;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace ASDP.FinalProject.UseCases.Employees.Queries
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeDto>>
    {
        private readonly IMapper _mapper;

        private AdspContext _context { get; set; }
        public GetEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = unitOfWork.GetContext();
            _mapper = mapper;
        }
        public async Task<List<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = _context.Employees.AsQueryable();

            if(request.Position != null)
            {
                employees = employees.Where(x => x.Position.Code == request.Position);
            }

            var res = await employees.ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider).ToListAsync();

            return res;
        }
    }
}
