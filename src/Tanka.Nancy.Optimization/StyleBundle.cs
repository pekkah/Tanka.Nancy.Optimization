namespace Tanka.Nancy.Optimization
{
    using System.Text;

    public abstract class StyleBundle : Bundle
    {
        protected StyleBundle(string path) : base(path)
        {
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