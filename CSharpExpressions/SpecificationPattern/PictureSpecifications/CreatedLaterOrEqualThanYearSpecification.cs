using SpecificationPattern.Lib;
using System.Linq.Expressions;

namespace SpecificationPattern.PictureSpecifications;

public sealed class CreatedLaterOrEqualThanYearSpecification : Specification<Picture>
{
    public CreatedLaterOrEqualThanYearSpecification(int year)
    {
        if (year < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(year));
        }

        Year = year;
    }

    public int Year { get; }

    public override Expression<Func<Picture, bool>> ToExpression()
    {
        return x => x.DateCreated.Year >= Year;
    }
}