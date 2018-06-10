using Kurs.Models;

namespace Kurs.ApiResults
{
    public class GetApiResult<TData> : ApiResult<TData>
    {
        public PaginationData Pagination { get; set; }
    }
}
