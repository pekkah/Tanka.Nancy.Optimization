namespace Tanka.Nancy.Optimization
{
    using System;
    using System.Collections.Generic;
    using global::Nancy;

    public class BundlerModule : NancyModule
    {
        public BundlerModule(IEnumerable<ScriptBundle> bundles)
        {
            if (bundles == null) throw new ArgumentNullException("bundles");

            foreach (ScriptBundle bundle in bundles)
                Get[bundle.Path] = parameters => bundle.Path;
        }
    }
}