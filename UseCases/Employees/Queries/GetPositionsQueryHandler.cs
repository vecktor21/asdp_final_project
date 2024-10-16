using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ASDP.FinalProject.UseCases.Employees.Dtos;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace ASDP.FinalProject.UseCases.Employees.Queries
{
    public class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, List<PositionDto>>
    {
        private readonly IMapper _mapper;

        private AdspContext _context { get; set; }
        public GetPositionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = unitOfWork.GetContext();
            _mapper = mapper;
        }
        public async Task<List<PositionDto>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Positions.Include(x => x.Permissions).ProjectTo<PositionDto>(_mapper.ConfigurationProvider).ToListAsync();
            return res;
        }
    }
}
