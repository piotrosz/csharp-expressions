using System.Linq.Expressions;
using SpecificationPattern.Lib;

namespace SpecificationPattern.PictureSpecifications;

public sealed class HasTagSpecification : Specification<Picture>
{
    public HasTagSpecification(string tag)
    {
        Tag = tag;
    }

    public string Tag { get; }

    public override Expression<Func<Picture, bool>> ToExpression()
    {
        return x => x.Tags.Contains(Tag);
    }
}