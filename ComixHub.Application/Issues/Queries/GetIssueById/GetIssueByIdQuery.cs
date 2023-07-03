using AutoMapper;
using ComixHub.Application.Issues.DTOs;
using ComixHub.Core.Services;
using ComixHub.Infrastructure.Extensions;
using MediatR;

namespace ComixHub.Application.Issues.Queries.GetIssueById
{
    public class GetIssueByIdQuery : IRequest<IssueDetailItem>
    {
        public string Id { get; set; }
    }

    public class GetIssueByIdQueryHandler : IRequestHandler<GetIssueByIdQuery, IssueDetailItem>
    {
        private readonly IComicsService _comicsService;
        private readonly IMapper _mapper;

        public GetIssueByIdQueryHandler(IComicsService comicsService, IMapper mapper)
        {
            _comicsService = comicsService;
            _mapper = mapper;
        }

        public async Task<IssueDetailItem> Handle(GetIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var issue = await _comicsService.GetIssueAsync(request.Id);
            return issue.MapTo<IssueDetailItem>(_mapper);
        }
    }
}
