namespace Tanka.Nancy.OptimizationTests
{
    using System.Text;
    using FluentAssertions;
    using global::Nancy;
    using global::Nancy.Testing;
    using Optimization;
    using Optimization.AjaxMin;
    using Xunit;

    public class MyScriptBundle : ScriptBundle
    {
        public MyScriptBundle() : base("/js/bundle.js")
        {
            Include("/Content/script1.js");
            Include("/Content/script2.js");
        }

        public string RenderHtml(bool optimize)
        {
            if (optimize)
                return RenderOptimizedHtml();

            return RenderUnoptimizedHtml();
        }

        private string RenderOptimizedHtml()
        {
            return string.Format("<script src=\"{0}\" />", Path);
        }

        private string RenderUnoptimizedHtml()
        {
            var builder = new StringBuilder();

            foreach (string file in Files)
            {
                builder.AppendLine(string.Format("<script src=\"{0}\" />", file));
            }

            return builder.ToString();
        }
    }

    public class ScriptBundlingFacts
    {
        public ScriptBundlingFacts()
        {
            BundleTable.Bundles.Clear();
        }

        [Fact]
        public void ShoudlRegisterBundleOnPath()
        {
            // arrange
            var browser =
                new Browser(
                    with =>
                    {
                        with.Module<BundlerModule>();

                        with.ApplicationStartup(
                            (ioc, context) =>
                            {
                                ioc.RegisterMultiple<ScriptBundle>(new[] {typeof (MyScriptBundle)});
                                ioc.Register<IBundler<ScriptBundle>, AjaxMinBundler>();
                            });
                    });

            // act
            BrowserResponse result = browser.Get("/js/bundle.js");
            
            // assert
            result.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public void ShouldRenderListOfScriptsWhenNotOptimizing()
        {
            // arrange
            var expectedHtml = new StringBuilder();
            expectedHtml.AppendLine("<script src=\"/Content/script1.js\" />");
            expectedHtml.AppendLine("<script src=\"/Content/script2.js\" />");

            var bundle = new MyScriptBundle();

            // act
            string html = bundle.RenderHtml(false);

            // assert
            html.ShouldBeEquivalentTo(expectedHtml.ToString());
        }

        [Fact]
        public void ShouldRenderScriptPointingToBundleWhenOptimizing()
        {
            // arrange
            const string expectedHtml = "<script src=\"/js/bundle.js\" />";

            var bundle = new MyScriptBundle();

            // act
            string html = bundle.RenderHtml(true);

            // assert
            html.ShouldBeEquivalentTo(expectedHtml);
        }
    }
}