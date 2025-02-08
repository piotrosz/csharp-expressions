namespace SpecificationPattern;

public static class PicturesDatabaseStub
{
    private static readonly IEnumerable<Picture> PictureSet = new List<Picture>
    {
        new()
        {
            DateCreated = new DateOnly(2020, 2, 1),
            Title = "Landscape 1",
            Description = "Countryside landscape",
            Tags = new List<string> { "cow" }
        },
        new()
        {
            DateCreated = new DateOnly(2021, 6, 13),
            Title = "Portrait",
            Tags = new List<string> { "portrait", "ink"}
        },
        new()
        {
            DateCreated = new DateOnly(1987, 6, 12),
            Title = "Untitled",
            Tags = new List<string> { "abstract"}
        },
        new()
        {
            DateCreated = new DateOnly(2022, 9, 2),
            Title = "Sernik",
            Tags = new List<string> { "abstract"}
        }
    };

    public static IQueryable<Picture> Pictures => PictureSet.AsQueryable();
}