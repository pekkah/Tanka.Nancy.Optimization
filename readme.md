Tanka Nancy Optimization framework
==================================

Simple prototype javascript and stylesheet optimization
framework. 

## Usage

```
// bundler core package
Install-Package Tanka.Nancy.Optimization -Pre

// install bundlers implemented using AjaxMin package
Install-Package Tanka.Nancy.Optimization.AjaxMin -Pre
```

Implement bundles by inheriting from ScriptBundle or StyleBundle.
Following the happy path will result in these bundles getting 
automatically registered by Nancy upon application startup.
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