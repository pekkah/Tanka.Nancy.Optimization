Tanka Nancy Optimization framework
==================================

Simple prototype javascript and stylesheet optimization
framework. 

## Usage

Register IScriptBundler and IStyleBundler implementations to your 
nancy bootstrapper container.

Example: Autofac Bootstrapper using the AjaxMin found in
Tanka.Nancy.Optimization.AjaxMin
```
builder.RegisterType<ScriptBundler>().AsImplementedInterfaces();
builder.RegisterType<StyleBundler>().AsImplementedInterfaces();

builder.RegisterAssemblyTypes(typeof (ThemeStyleBundle).Assembly)
       .Where(type => typeof (StyleBundle).IsAssignableFrom(type))
       .As<StyleBundle>()
       .SingleInstance();

builder.RegisterAssemblyTypes(typeof (CoreScriptBundle).Assembly)
       .Where(type => typeof (ScriptBundle).IsAssignableFrom(type))
       .As<ScriptBundle>()
       .SingleInstance();

```

Implement bundles by inheriting from ScriptBundle or StyleBundle
```
public class CoreScriptBundle : ScriptBundle
{
    public CoreScriptBundle() : base("/js/core.js")
    {
       Include("/Scripts/jquery-2.0.3.min.js");
       Include("/Scripts/modernizr-2.7.1.js");
       Include("/Scripts/moment-with-langs.js");
    }
}

public class ThemeStyleBundle : StyleBundle
{
   public ThemeStyleBundle() : base("/css/theme.css")
   {
      Include("/Content/themes/default/bootstrap.css");
   }
}
```

Both base classes take the virtual path to the bundle as constructor parameter.

Enable or disable the bundling by using `Bundler.Enable(bool optimize)` in your
application startup. 

Use bundles in your views (Razor only at the moment)

```
@Styles.Render("/css/theme.css")
@Scripts.Render("/js/core.js")
```