using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.UseCases.Documents.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Documents.Queries
{
    public class GetTemplatesQueryHandler : IRequestHandler<GetTemplatesQuery, List<TemplateResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTemplatesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<TemplateResponse>> Handle(GetTemplatesQuery request, CancellationToken cancellationToken)
        {
            var context = _unitOfWork.GetContext();
            var templates = await context.Templates.ToListAsync();
            return _mapper.Map<List<TemplateResponse>>(templates);
        }
    }
}
