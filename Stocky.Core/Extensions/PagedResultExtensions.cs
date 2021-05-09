using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Core.Extensions
{
    public static partial class Extensions
    {
        public static PagedResult<T> GetPaged<T>(this IEnumerable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalRecords = query.Count()
            };

            var pageCount = (double)result.TotalRecords / pageSize;
            result.TotalPages = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IEnumerable<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }

    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public int FirstRecordOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRecordOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, TotalRecords); }
        }

        public bool HasPrevious
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNext
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }

    }
}
