using AutoMapper;
using ComixHub.Application.Common;
using ComixHub.Application.Issues.DTOs;
using ComixHub.Core.Filters;
using ComixHub.Core.Services;
using ComixHub.Infrastructure.Extensions;
using ComixHub.Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ComixHub.Application.Issues.Queries.GetIssues
{
    public class GetIssuesQuery : IssueFilters, IRequest<PaginatedResponse<IssueListItem>>, IPaginatedQuery, ISortableQuery
    {
        public string SortBy { get; set; }
        public bool SortDescending { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetIssuesQueryHandler : IRequestHandler<GetIssuesQuery, PaginatedResponse<IssueListItem>>
    {
        private readonly IComicsService _comicsService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetIssuesQueryHandler(IComicsService comicsService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _comicsService = comicsService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PaginatedResponse<IssueListItem>> Handle(GetIssuesQuery request, CancellationToken cancellationToken)
        {
            var queryParams = new QueryParameters<IssueFilters>()
            {
                Filters = request,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SortBy = request.SortBy,
                SortDescending = request.SortDescending
            };
            var (issues, total) = await _comicsService.GetIssuesAsync(queryParams);

            var resultItems = issues.MapTo<IssueListItem>(_mapper);

            return new PaginatedResponse<IssueListItem>()
            {
                Items = resultItems,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Total = total
            };
        }
    }
}
