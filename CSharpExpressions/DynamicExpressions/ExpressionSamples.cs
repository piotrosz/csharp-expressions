using System.Linq.Expressions;

namespace DynamicExpressions
{
    public static class ExpressionSamples
    {
        public static int AddTwoInts(int a, int b)
        {
            var aExpr = Expression.Constant(a, typeof(int));
            var bExpr = Expression.Constant(b, typeof(int));
            var addition = Expression.Add(aExpr, bExpr);

            var lambda = Expression.Lambda<Func<int>>(addition);

            Func<int> compiled = lambda.Compile();

            return compiled();
        }

        public static IEnumerable<Expense> DynamicFilterByCategoryNameAndAmount(string categoryName, decimal amount)
        {
            var expenses = new List<Expense>
            {
                new("entertainment", 34),
                new("entertainment", 1),
                new("bills", 232),
                new("car", 9090)
            };

            var categoryConstant = Expression.Constant(categoryName);

            var expenseParameter = Expression.Parameter(typeof(Expense));
            var categoryNameProperty = Expression.Property(expenseParameter, nameof(Expense.CategoryName));
            var categoryEquals = Expression.Equal(categoryNameProperty, categoryConstant);
            
            var amountConstant = Expression.Constant(amount);
            var amountProperty = Expression.Property(expenseParameter, nameof(Expense.Amount));
            var amountGreaterThan = Expression.GreaterThan(amountProperty, amountConstant);

            var filter = Expression.And(categoryEquals, amountGreaterThan);
            var lambda = Expression.Lambda<Func<Expense, bool>>(filter, expenseParameter);
            
            Func<Expense, bool> func = lambda.Compile();
            return expenses.Where(func);
        }
    }

    public readonly record struct Expense(string CategoryName, decimal Amount);
}