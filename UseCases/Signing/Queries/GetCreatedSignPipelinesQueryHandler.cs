using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Helpers;
using ASDP.FinalProject.UseCases.Signing.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Resources;

namespace ASDP.FinalProject.UseCases.Signing.Queries
{
    public class GetCreatedSignPipelinesQueryHandler : IRequestHandler<GetCreatedSignPipelinesQuery, List<DocumentToSignDto>>
    {
        private readonly IMapper _mapper;
        private readonly AdspContext _context;
        public GetCreatedSignPipelinesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _context = unitOfWork.GetContext();
        }

        public async Task<List<DocumentToSignDto>> Handle(GetCreatedSignPipelinesQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees
                .Include(x=>x.CreatedSignPipelines)
                .ThenInclude(x=>x.SignDocument)
                .Include(x=> x.CreatedSignPipelines)
                .ThenInclude(x=> x.Signers)
                .ThenInclude(x=> x.SignerEmployee)
                .SingleAsync(x => x.Id == request.UserId);

            var createdPipelines = employee.CreatedSignPipelines;

            var res = _mapper.Map<List<DocumentToSignDto>>(createdPipelines);

            return res;
        }
    }
}
