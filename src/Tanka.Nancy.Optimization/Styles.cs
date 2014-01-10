namespace Tanka.Nancy.Optimization
{
    using System;
    using global::Nancy.ViewEngines.Razor;

    public static class Styles
    {
        public static IHtmlString Render(string bundlePath)
        {
            // If only I could access the IoC container from here :(
            // I could get rid of the BundleTable and resolve the bundle
            // here and render the list of files or file

            var bundle = BundleTable.Bundles.Get(bundlePath) as StyleBundle;

            if (bundle == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Could not render bundle {0}. It doesn't exist or is not StyleBundle",
                        bundlePath));
            }

            bool optimize = BundleTable.Bundles.Optimize;

            return new NonEncodedHtmlString(bundle.RenderHtml(optimize));
        }
    }
}