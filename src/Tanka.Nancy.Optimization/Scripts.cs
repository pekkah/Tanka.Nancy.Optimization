namespace Tanka.Nancy.Optimization
{
    using System.Text;
    using global::Nancy.ViewEngines.Razor;

    public static class Scripts
    {
        public static IHtmlString Render(this NancyRazorViewBase view, string modulePath)
        {
            // If only I could access the IoC container from here :(
            // I could get rid of the BundleTable and resolve the bundle
            // here and render the list of files or file
            var builder = new StringBuilder();

            Bundle bundle = BundleTable.Bundles.Get(modulePath);

            return view.Html.Raw(builder.ToString());
        }
    }
}