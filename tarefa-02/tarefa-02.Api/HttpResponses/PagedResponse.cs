using System;

namespace tarefa_02.HttpResponses
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages
        {
            get
            {
                double totalPages = (double)TotalRecords / PageSize;
                return Convert.ToInt32(Math.Ceiling(totalPages));
            }
        }
        public int TotalRecords { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            TotalRecords = totalRecords;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }
}