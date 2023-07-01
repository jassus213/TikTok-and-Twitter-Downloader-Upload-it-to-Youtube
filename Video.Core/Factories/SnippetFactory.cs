using Video.Core.Entities;

namespace Video.Core.Factories
{
    public static class SnippetFactory
    {
        public static VideoSnippet CreateVideoSnippet(string title, string description)
        {
            return new VideoSnippet
            {
                Title = title,
                Description = description,
                CategoryId = "22",
            };

        }
    }
}