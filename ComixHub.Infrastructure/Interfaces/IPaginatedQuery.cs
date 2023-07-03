﻿namespace ComixHub.Infrastructure.Interfaces
{
    public interface IPaginatedQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
