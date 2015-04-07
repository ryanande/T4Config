# T4Config

A down and dirty way to have strongly typed Config Settings and Connection Strings in your projects by using T4.

In a nutshell we create an interface called IConfigurations/ IConnectionStrings, so you can do all your fancy DI/IoC stuff, and a concrete implementation called Configurations/ ConnectionStrings. (both names totally customizable.

The T4 template loops through the web.config (or app.config) appSettings and generates a read only property for each key and returns the values placed in the settings value.

If you have a configuration section of appSettings which looked like this;

```xml
<appSettings>
    <add key="Key1" value="value1" />
    <add key="Key2" value="2212DE83-DFC3-44A8-81BA-0A8D132C1F79" />
    <add key="Key3" value="42" />
</appSettings>
```

After the T4 file compiles you would end up with this;

```csharp
public interface IConfigurations
{
	string Key1 { get; }
	Guid Key2 { get; }
	int Key3 { get; }
	bool Key4 { get; }
}

public class Configurations : IConfigurations
{
	private static readonly Lazy<string> _key1 = new Lazy<string>(() => ConfigurationManager.AppSettings["Key1"]);
	private static readonly Lazy<Guid> _key2 = new Lazy<Guid>(() => new Guid(ConfigurationManager.AppSettings["Key2"]));
	private static readonly Lazy<int> _key3 = new Lazy<int>(() => Convert.ToInt32(ConfigurationManager.AppSettings["Key3"]));
	private static readonly Lazy<bool> _key3 = new Lazy<bool>(() => Convert.ToBoolean(ConfigurationManager.AppSettings["Key4"]));

	public virtual string Key1 
	{
		get 
		{
			return _key1.Value;
		}
	}
	public virtual Guid Key2 
	{
		get 
		{
			return _key2.Value;
		}
	}
	public virtual int Key3 
	{
		get 
		{
			return _key3.Value;
		}
	}
	public virtual bool Key4 
	{
		get 
		{
			return _key4.Value;
		}
	}
}

public interface IConnectionStrings
{
	string LocalSqlServer { get; }
}

public class ConnectionStrings : IConnectionStrings
{
	private static readonly Lazy<string> _localSqlServer = new Lazy<string>(() => ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

	public virtual string LocalSqlServer 
	{
		get 
		{
			return _localSqlServer.Value;
		}
	}
}
```

Same goes for connection strings as well!

##Install
Can be install from Nuget as well;

    Install-Package T4Config

https://www.nuget.org/packages/T4Config/

## How do I do it?
- Copy the Configurations.tt file from the src directory to your project.
- Update the configFile value to the proper config file (web or app).
- Right click on the file and click "Run Custom Tool".

Enjoy!
