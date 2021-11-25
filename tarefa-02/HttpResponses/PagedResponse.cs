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
                var totalPages = (double)TotalRecords / (double)PageSize;
                return Convert.ToInt32(Math.Ceiling(totalPages));
            }
        }
        public int TotalRecords { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}