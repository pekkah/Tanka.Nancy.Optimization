namespace Tanka.Nancy.Optimization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Nancy.Bootstrapper;

    public class BundlerRegistration : IApplicationRegistrations
    {
        public IEnumerable<TypeRegistration> TypeRegistrations
        {
            get { return null; }
        }

        public IEnumerable<CollectionTypeRegistration> CollectionTypeRegistrations
        {
            get { return null; }
        }

        public IEnumerable<InstanceRegistration> InstanceRegistrations
        {
            get
            {
                IEnumerable<ScriptBundle> scriptBundles = AppDomainAssemblyTypeScanner
                    .TypesOf<ScriptBundle>()
                    .Select(type => (ScriptBundle) Activator.CreateInstance(type))
                    .ToList();

                yield return new InstanceRegistration(
                    typeof (IEnumerable<ScriptBundle>),
                    scriptBundles);

                IEnumerable<StyleBundle> styleBundles = AppDomainAssemblyTypeScanner
                    .TypesOf<StyleBundle>()
                    .Select(type => (StyleBundle) Activator.CreateInstance(type))
                    .ToList();

                yield return new InstanceRegistration(typeof (IEnumerable<StyleBundle>),
                    styleBundles);
            }
        }
    }
}