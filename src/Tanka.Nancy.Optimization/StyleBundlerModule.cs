namespace Tanka.Nancy.Optimization
{
    using System;
    using System.Collections.Generic;
    using global::Nancy;

    public class StyleBundlerModule : NancyModule
    {
        public StyleBundlerModule(IEnumerable<StyleBundle> bundles, IStyleBundler bundler)
        {
            if (bundles == null) throw new ArgumentNullException("bundles");

            foreach (StyleBundle bundle in bundles)
            {
                StyleBundle local = bundle;

                Get[bundle.Path] = parameters =>
                {
                    string content = bundler.Bundle(local);

                    return Response.AsText(content, "text/css");
                };
            }
        }
    }
}