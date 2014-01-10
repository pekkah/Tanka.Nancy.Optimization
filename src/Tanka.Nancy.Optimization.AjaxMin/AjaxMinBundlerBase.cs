namespace Tanka.Nancy.Optimization.AjaxMin
{
    using System;
    using System.IO;
    using System.Text;
    using global::Nancy;

    public abstract class AjaxMinBundlerBase
    {
        private readonly IRootPathProvider _rootPathProvider;

        protected AjaxMinBundlerBase(IRootPathProvider rootPathProvider)
        {
            _rootPathProvider = rootPathProvider;
        }

        protected string Combine(Bundle bundle)
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
            return combined;
        }

        private string GetFullPath(string path)
        {
            string rootPath = _rootPathProvider.GetRootPath();
            return Path.Combine(rootPath, path.TrimStart('/'));
        }
    }
}