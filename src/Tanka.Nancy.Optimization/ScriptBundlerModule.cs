namespace Tanka.Nancy.Optimization
{
    using System;
    using System.Collections.Generic;
    using global::Nancy;

    public class ScriptBundlerModule : NancyModule
    {
        public ScriptBundlerModule(IEnumerable<ScriptBundle> bundles, IScriptBundler bundler)
        {
            if (bundles == null) throw new ArgumentNullException("bundles");

            foreach (ScriptBundle bundle in bundles)
            {
                ScriptBundle local = bundle;

                Get[bundle.Path] = parameters =>
                {
                    string content = bundler.Bundle(local);

                    return Response.AsText(content, "application/javascript");
                };
            }
        }
    }
}