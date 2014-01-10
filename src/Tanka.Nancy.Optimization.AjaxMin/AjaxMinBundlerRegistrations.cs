namespace Tanka.Nancy.Optimization.AjaxMin
{
    using System.Collections.Generic;
    using global::Nancy.Bootstrapper;

    public class AjaxMinBundlerRegistrations : IApplicationRegistrations
    {
        public IEnumerable<TypeRegistration> TypeRegistrations
        {
            get
            {
                yield return new TypeRegistration(typeof(IScriptBundler), typeof(ScriptBundler));
                yield return new TypeRegistration(typeof(IStyleBundler), typeof(StyleBundler));
            }
        }

        public IEnumerable<CollectionTypeRegistration> CollectionTypeRegistrations
        {
            get
            {
                return null;
            }
        }

        public IEnumerable<InstanceRegistration> InstanceRegistrations
        {
            get
            {
                return null;
            }
        }
    }
}