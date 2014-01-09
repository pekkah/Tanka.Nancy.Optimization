namespace Tanka.Nancy.Optimization
{
    using System;
    using System.Collections.Generic;
    using global::Nancy;

    public class BundlerModule : NancyModule
    {
        public BundlerModule(IEnumerable<ScriptBundle> bundles, IBundler<ScriptBundle> bundler)
        {
            if (bundles == null) throw new ArgumentNullException("bundles");

            foreach (ScriptBundle bundle in bundles)
            {
                ScriptBundle local = bundle;

                Get[bundle.Path] = parameters =>
                {
                    var content = bundler.Bundle(local);

                    return Response.AsText(content, "text/javascript");
                };
            }
        }
    }

    public interface IBundler<in T> where T: Bundle
    {
        string Bundle(T bundle);
    }
}