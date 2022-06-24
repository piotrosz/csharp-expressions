using SpecificationPattern.Lib;

namespace SpecificationPattern
{
    public sealed class PictureRepository
    {
        public IEnumerable<Picture> GetPictures(Specification<Picture> specification)
        {
            return PicturesDatabaseStub.Pictures.Where(specification.ToExpression());
        }
    }
}
