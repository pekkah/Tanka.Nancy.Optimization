namespace Tanka.Nancy.Optimization
{
    using System.Linq;
    using System.Reflection;

    public static class Bundler
    {
        public static void Enable(bool optimize)
        {
            BundleTable.Bundles.Optimize = optimize;
        }
    }
}