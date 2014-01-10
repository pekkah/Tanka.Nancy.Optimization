namespace Tanka.Nancy.Optimization
{
    using System.Collections.Generic;

    public abstract class Bundle
    {
        private readonly List<string> _files;

        protected Bundle(string path)
        {
            Path = path;
            _files = new List<string>();

            BundleTable.Bundles.Add(this);
        }

        public string Path { get; private set; }

        public IEnumerable<string> Files
        {
            get { return _files; }
        }

        public void Include(string file)
        {
            _files.Add(file);
        }

        public string RenderHtml(bool optimize)
        {
            if (optimize)
                return RenderOptimizedHtml();

            return RenderUnoptimizedHtml();
        }

        protected abstract string RenderOptimizedHtml();
        protected abstract string RenderUnoptimizedHtml();
    }
}