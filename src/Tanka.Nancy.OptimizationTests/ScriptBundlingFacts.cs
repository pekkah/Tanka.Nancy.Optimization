namespace Tanka.Nancy.OptimizationTests
{
    using System.Text;
    using FluentAssertions;
    using global::Nancy;
    using global::Nancy.Testing;
    using Optimization;
    using Xunit;

    public class MyScriptBundle : ScriptBundle
    {
        public MyScriptBundle() : base("/js/bundle.js")
        {
            Include("/Content/script1.js");
            Include("/Content/script2.js");
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
                    with => with.Module<ScriptBundlerModule>());

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
            expectedHtml.AppendLine("<script src=\"/Content/script1.js\"></script>");
            expectedHtml.AppendLine("<script src=\"/Content/script2.js\"></script>");

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
            const string expectedHtml = "<script src=\"/js/bundle.js\"></script>";

            var bundle = new MyScriptBundle();

            // act
            string html = bundle.RenderHtml(true);

            // assert
            html.ShouldBeEquivalentTo(expectedHtml);
        }
    }
}