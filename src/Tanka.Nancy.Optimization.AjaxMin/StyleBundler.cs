namespace Tanka.Nancy.Optimization.AjaxMin
{
    using global::Nancy;
    using Microsoft.Ajax.Utilities;

    public class StyleBundler : AjaxMinBundlerBase, IStyleBundler
    {
        private readonly Minifier _minifier;

        public StyleBundler(IRootPathProvider rootPathProvider) : base(rootPathProvider)
        {
            _minifier = new Minifier();
        }

        public string Bundle(StyleBundle bundle)
        {
            string combined = Combine(bundle);

            return _minifier.MinifyStyleSheet(combined);
        }
    }
}