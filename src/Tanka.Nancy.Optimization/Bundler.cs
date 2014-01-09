namespace Tanka.Nancy.Optimization
{
    public static class Bundler
    {
        public static void Enable(bool optimize)
        {
            BundleTable.Bundles.Optimize = optimize;
        }
    }
}