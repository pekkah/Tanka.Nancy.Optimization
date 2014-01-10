namespace Tanka.Nancy.Optimization.AjaxMin
{
    using global::Nancy;
    using Microsoft.Ajax.Utilities;

    public class ScriptBundler : AjaxMinBundlerBase, IScriptBundler
    {
        private readonly Minifier _minifier;

        public ScriptBundler(IRootPathProvider rootPathProvider) : base(rootPathProvider)
        {
            _minifier = new Minifier();
        }

        public string Bundle(ScriptBundle bundle)
        {
            string combined = Combine(bundle);

            return _minifier.MinifyJavaScript(combined);
        }
    }
}