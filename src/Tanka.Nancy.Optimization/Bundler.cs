namespace Tanka.Nancy.Optimization
{
    public static class Bundler
    {
        public static void Enable(bool optimize)
        {
            BundleTable.Bundles.Optimize = optimize;
            BundleTable.Bundles.Cache = new MemoryCache();
        }

        public static void Enable(bool optimize, IBundleCache cache)
        {
            BundleTable.Bundles.Optimize = optimize;
            BundleTable.Bundles.Cache = cache;
        }
    }
}