using System;
using System.Collections.Generic;
using System.Text;

using System.Linq.Expressions;

namespace AMLRS.Core.QueryModels
{
    public static class GenericFilterHelper
    {
        public static IQueryable<T> ApplySearch<T>(
            IQueryable<T> query,
            string? searchText,
            params Expression<Func<T, string?>>[] properties)
        {
            {
                if (string.IsNullOrWhiteSpace(searchText) || properties == null || properties.Length == 0)
                    return query;

                searchText = searchText.ToLower();

                Expression? body = null;
                var parameter = Expression.Parameter(typeof(T), "x");

                foreach (var prop in properties)
                {
                    if (prop == null) continue;

                    Expression expr = prop.Body;

                    // 🔑 THIS IS THE FIX
                    if (expr is UnaryExpression unary)
                        expr = unary.Operand;

                    if (expr is not MemberExpression member)
                        continue;

                    var property = Expression.Property(parameter, member.Member.Name);

                    var notNull = Expression.NotEqual(
                        property,
                        Expression.Constant(null, typeof(string))
                    );

                    var toLower = Expression.Call(property, nameof(string.ToLower), null);

                    var contains = Expression.Call(
                        toLower,
                        nameof(string.Contains),
                        null,
                        Expression.Constant(searchText)
                    );

                    var condition = Expression.AndAlso(notNull, contains);

                    body = body == null ? condition : Expression.OrElse(body, condition);
                }

                if (body == null)
                    return query;

                var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                return query.Where(lambda);
            }
        }
    }

}