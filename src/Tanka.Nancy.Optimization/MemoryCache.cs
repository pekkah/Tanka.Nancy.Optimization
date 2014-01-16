namespace Tanka.Nancy.Optimization
{
    using System;
    using System.Collections.Concurrent;
    using global::Nancy;
    using global::Nancy.Responses;

    public class MemoryCache : IBundleCache
    {
        private readonly ConcurrentDictionary<string, Response> _cache;

        public MemoryCache()
        {
            _cache = new ConcurrentDictionary<string, Response>();
        }

        public Response Get<T>(T bundle, Func<T, string> contentFactory) where T : Bundle
        {
            ShouldPruneCache();

            return _cache.GetOrAdd(bundle.GetCacheKey(), _ =>
            {
                string content = contentFactory(bundle);

                return new TextResponse(content, bundle.ContentType);
            });
        }

        private void ShouldPruneCache()
        {
            // todo: prune old entries from cache
        }
    }
}