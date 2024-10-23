﻿using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Services;
using ASDP.FinalProject.UseCases.Signing.Dtos;
using MediatR;

namespace ASDP.FinalProject.UseCases.Documents.Commands
{
    public class GenerateSignDocumentCommandHandler : IRequestHandler<GenerateSignDocumentCommand, DocumentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITagsService _tagsService;
        private readonly AdspContext _context;

        public GenerateSignDocumentCommandHandler(IUnitOfWork unitOfWork, ITagsService tagsService)
        {
            _unitOfWork = unitOfWork;
            _tagsService = tagsService;
            _context = unitOfWork.GetContext();
        }

        public async Task<DocumentDto> Handle(GenerateSignDocumentCommand request, CancellationToken cancellationToken)
        {
            var template = _context.Templates.Single(x => x.Id == request.TemplateId);

            using var ms = new MemoryStream();
            ms.Write(template.Content);

            var filledDocumentStream = (MemoryStream)await _tagsService.FillTags(ms, new SignContext(request.CreatorUserId, request.TeamleadId, request.DirectorId));

            var content = filledDocumentStream.ToArray();

            return new DocumentDto
            {
                ConentType = template.ContentType,
                Content = content,
                Name = template.Name
            };
        }
    }
}
