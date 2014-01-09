namespace Tanka.Nancy.Optimization.AjaxMin
{
    using System;
    using System.IO;
    using System.Text;
    using global::Nancy;
    using Microsoft.Ajax.Utilities;

    public class AjaxMinBundler : IBundler<ScriptBundle>
    {
        private readonly Minifier _minifier;
        private readonly IRootPathProvider _rootPathProvider;

        public AjaxMinBundler(IRootPathProvider rootPathProvider)
        {
            _rootPathProvider = rootPathProvider;
            _minifier = new Minifier();
        }

        public string Bundle(ScriptBundle bundle)
        {
            var builder = new StringBuilder();

            foreach (string file in bundle.Files)
            {
                string fullPath = GetFullPath(file);

                if (!File.Exists(fullPath))
                    throw new InvalidOperationException(
                        string.Format("Could not load bundled file {0}", fullPath));

                string content = File.ReadAllText(fullPath);
                builder.Append(content);
            }

            string combined = builder.ToString();

            return _minifier.MinifyJavaScript(combined);
        }

        private string GetFullPath(string path)
        {
            path = path.TrimStart('/');
            
            var rootPath = _rootPathProvider.GetRootPath();
            return Path.Combine(rootPath, path);
        }
    }
}