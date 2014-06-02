﻿namespace Tanka.Nancy.OptimizationTests
{
    using System.Text;
    using FluentAssertions;
    using global::Nancy;
    using global::Nancy.Testing;
    using Optimization;
    using Xunit;

    public class MyStyleBundle : StyleBundle
    {
        public MyStyleBundle() : base("/css/bundle.css")
        {
            Include("/Content/style1.css");
            Include("/Content/style2.css");
        }
    }

    public class StyleBundlingFacts
    {
        public StyleBundlingFacts()
        {
            BundleTable.Bundles.Clear();
            Bundler.Enable(false);
        }

        [Fact]
        public void ShoudlRegisterBundleOnPath()
        {
            // arrange
            var browser =
                new Browser(
                    with => with.Module<StyleBundlerModule>());

            // act
            BrowserResponse result = browser.Get("/css/bundle.css");

            // assert
            result.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ContentType.ShouldAllBeEquivalentTo("text/css;charset=utf-8");
        }

        [Fact]
        public void ShouldRenderListOfStylesWhenNotOptimizing()
        {
            // arrange
            var expectedHtml = new StringBuilder();
            expectedHtml.AppendLine("<link rel=\"stylesheet\" href=\"/Content/style1.css\" />");
            expectedHtml.AppendLine("<link rel=\"stylesheet\" href=\"/Content/style2.css\" />");

            var bundle = new MyStyleBundle();

            // act
            string html = bundle.RenderHtml(false);

            // assert
            html.ShouldBeEquivalentTo(expectedHtml.ToString());
        }

        [Fact]
        public void ShouldRenderStylePointingToBundleWhenOptimizing()
        {
            // arrange
            const string expectedHtml = "<link rel=\"stylesheet\" href=\"/css/bundle.css\" />";

            var bundle = new MyStyleBundle();

            // act
            string html = bundle.RenderHtml(true);

            // assert
            html.ShouldBeEquivalentTo(expectedHtml);
        }
    }
}