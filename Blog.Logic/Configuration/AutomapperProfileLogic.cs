using System;

using AutoMapper;

namespace Blog.Logic.Configuration
{
    public class AutomapperProfileLogic : Profile
    {
        public AutomapperProfileLogic()
        {

        }
    }

    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            if (expression is null) throw new ArgumentNullException(nameof(expression));

            expression.ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            return expression;
        }
    }
}
