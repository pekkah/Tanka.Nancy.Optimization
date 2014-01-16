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

                Get[bundle.Path] = parameters => BundleTable.Bundles.Cache.Get(local, bundler.Bundle);
            }
        }
    }
}