namespace Tanka.Nancy.Optimization
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    public class BundleTable
    {
        private static readonly Lazy<BundleTable> TableLazy = new Lazy<BundleTable>(CreateTable);

        private ConcurrentBag<Bundle> _bundles;

        protected BundleTable()
        {
            _bundles = new ConcurrentBag<Bundle>();
        }

        public static BundleTable Bundles
        {
            get { return TableLazy.Value; }
        }

        public bool Optimize { get; set; }

        private static BundleTable CreateTable()
        {
            return new BundleTable();
        }

        public void Add(Bundle bundle)
        {
            if (_bundles.Any(b => b.Path == bundle.Path))
                throw new ArgumentOutOfRangeException("bundle", "Bundle for path is already added");

            _bundles.Add(bundle);
        }

        public Bundle Get(string modulePath)
        {
            return _bundles.SingleOrDefault(module => module.Path == modulePath);
        }

        public void Clear()
        {
            _bundles = new ConcurrentBag<Bundle>();
        }
    }
}