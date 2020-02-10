using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using TODO_HTTP_API.BusinessLogic.Helpers.Interfaces;
using System.Linq.Dynamic.Core;

namespace TODO_HTTP_API.BusinessLogic.Helpers.Services
{
	public class SortHelper<T> : ISortHelper<T>
	{
		public IQueryable<T> ApplySort(IQueryable<T> entities, QueryStringParameters queryString)
		{
			if (!entities.Any())
				return entities;

			if (string.IsNullOrWhiteSpace(queryString.OrderBy))
			{
				return entities;
			}

			var orderParams = queryString.OrderBy.Trim().Split(',');
			var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var orderQueryBuilder = new StringBuilder();

			foreach (var param in orderParams)
			{
				if (string.IsNullOrWhiteSpace(param))
					continue;

				var propertyFromQueryName = param.Split(" ")[0];
				var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

				if (objectProperty == null)
					continue;

				var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

				orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder},  ");
			}

			var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

			return entities.OrderBy(orderQuery);
		}
	}
	//static class IQueryableExtension
	//{
	//	public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, params object[] values)
	//	{
	//		var type = typeof(T);
	//		var property = type.GetProperty(ordering);
	//		var parameter = Expression.Parameter(type, "p");
	//		var propertyAccess = Expression.MakeMemberAccess(parameter, property);
	//		var orderByExp = Expression.Lambda(propertyAccess, parameter);
	//		MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
	//		return source.Provider.CreateQuery<T>(resultExp);
	//	}
	//}
}
