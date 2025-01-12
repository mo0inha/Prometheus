using System.Linq.Expressions;

namespace Application.Shared
{
    public static class FilterBuilder
    {

        public static Expression<Func<T, bool>> New<T>()
        {
            return f => true;
        }

        // Concatena duas expressões com AND (ambas precisam ser verdadeiras)
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            // Invoca a expressão expr2 com os parâmetros de expr1
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        // Concatena duas expressões com OR (uma das expressões precisa ser verdadeira)
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            // Invoca a expressão expr2 com os parâmetros de expr1
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        // Método para aplicar filtros diretamente na query
        public static IQueryable<T> ApplyPredicate<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate)
        {
            return query.Where(predicate);
        }
    }
}