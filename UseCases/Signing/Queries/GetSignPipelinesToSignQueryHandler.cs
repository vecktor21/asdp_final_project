using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.DAL;
using ASDP.FinalProject.UseCases.Signing.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.UseCases.Signing.Queries
{
    public class GetSignPipelinesToSignQueryHandler : IRequestHandler<GetSignPipelinesToSignQuery, List<DocumentToSignDto>>
    {
        private readonly IMapper _mapper;
        private readonly AdspContext _context;
        public GetSignPipelinesToSignQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _context = unitOfWork.GetContext();
        }

        public async Task<List<DocumentToSignDto>> Handle(GetSignPipelinesToSignQuery request, CancellationToken cancellationToken)
        {
            var signPipelines = await _context.SignPipeline
                .Include(x => x.Signers)
                .Include(x=>x.SignDocument)
                .Where(x =>
                    x.Status != SignPipelineStatus.Rejected
                    && x.Signers.OrderBy(o => o.Order)
                        .First(f => !f.IsSigned)
                        .SignerEmployeeId == request.UserId
                    )
                .ToListAsync();

            var res = _mapper.Map<List<DocumentToSignDto>>(signPipelines);

            return res;
        }
    }
}
