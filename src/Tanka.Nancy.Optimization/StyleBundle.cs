namespace Tanka.Nancy.Optimization
{
    using System.Text;

    public abstract class StyleBundle : Bundle
    {
        protected StyleBundle(string path) : base(path)
        {
        }

        public override string ContentType
        {
            get { return "text/css;charset=utf-8"; }
        }

        protected override string RenderOptimizedHtml()
        {
            // <link rel="stylesheet" href="/tanka/theme.css">
            return string.Format("<link rel=\"stylesheet\" href=\"{0}\" />", Path);
        }

        protected override string RenderUnoptimizedHtml()
        {
            var builder = new StringBuilder();

            foreach (string file in Files)
            {
                builder.AppendLine(string.Format("<link rel=\"stylesheet\" href=\"{0}\" />", file));
            }

            return builder.ToString();
        }
    }
}