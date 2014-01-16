namespace Tanka.Nancy.Optimization
{
    using System.Text;

    public abstract class ScriptBundle : Bundle
    {
        protected ScriptBundle(string path) : base(path)
        {
        }

        public override string ContentType
        {
            get { return "application/javascript;charset=utf-8"; }
        }

        protected override string RenderOptimizedHtml()
        {
            return string.Format("<script src=\"{0}\"></script>", Path);
        }

        protected override string RenderUnoptimizedHtml()
        {
            var builder = new StringBuilder();

            foreach (string file in Files)
            {
                builder.AppendLine(string.Format("<script src=\"{0}\"></script>", file));
            }

            return builder.ToString();
        }
    }
}