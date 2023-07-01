namespace Video.Core.Factories
{
    public static class VideoFactory
    {
        public static Entities.Video CreateVideo(string tittle, string description,  bool isPrivate,
            bool isYoutubeShorts)
        {
            switch (isYoutubeShorts)
            {
                case true:
                    return new Entities.Video
                    {
                        Snippet = SnippetFactory.CreateVideoSnippet($"#shorts{tittle}", $"#shorts{description}"),
                    };
                case false:
                    return new Entities.Video
                    {
                        Snippet = SnippetFactory.CreateVideoSnippet(tittle, description),
                    };
            }
        }
    }
}