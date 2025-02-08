using FluentAssertions;
using SpecificationPattern.PictureSpecifications;

namespace SpecificationPattern.Tests;

public class PictureRepositoryTests
{
    [Fact]
    public void Test1()
    {
        var sut = new PictureRepository();

        var specification = new CreatedLaterOrEqualThanYearSpecification(2020)
            .And(new HasTagSpecification("abstract"));

        var result = sut.GetPictures(specification);

        result.Single().Title.Should().Be("Sernik");
    }
}