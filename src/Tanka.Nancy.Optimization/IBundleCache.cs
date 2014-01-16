namespace Tanka.Nancy.Optimization
{
    using System;
    using global::Nancy;

    public interface IBundleCache
    {
        Response Get<T>(T bundle, Func<T, string> contentFactory) where T : Bundle;
    }
}