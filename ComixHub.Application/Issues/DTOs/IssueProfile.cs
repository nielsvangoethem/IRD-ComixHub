using AutoMapper;
using ComixHub.Core.Models;

namespace ComixHub.Application.Issues.DTOs
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<Issue, IssueListItem>();
            CreateMap<Issue, IssueDetailItem>();
        }
    }
}
