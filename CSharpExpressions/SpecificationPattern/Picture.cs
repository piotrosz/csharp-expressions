namespace SpecificationPattern
{
    public record Picture
    {
        public string Title { get; init; }

        public string Description { get; init; }

        public DateOnly DateCreated { get; init; }

        public IEnumerable<string> Tags { get; init; }
    }
}