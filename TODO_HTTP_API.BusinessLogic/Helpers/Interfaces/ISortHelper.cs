using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TODO_HTTP_API.BusinessLogic.Helpers.Interfaces
{
    public interface ISortHelper<T>
    {
        IQueryable<T> ApplySort(IQueryable<T> entities, QueryStringParameters orderByQueryString);
    }
}
