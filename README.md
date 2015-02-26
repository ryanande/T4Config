# T4Config

A down and dirty way to have strongly typed App Settings and Connection Strings using T4.

In a nutshell we create an interface called IConfigurations/ IConnectionStrings, so you can do all your fancy DI/IoC stuff, and a concrete implementation called Configurations/ ConnectionStrings. (both names totally customizable.

The T4 template loops through the web.config or app.config appSettings and generates a read only property for each key and returns the values placed in the settings value.

If you have a configuration section of appSettings which looked like this;

    <appSettings>
    	<add key="Key1" value="value1" />
    	<add key="Key2" value="value2" />
	</appSettings>

After the T4 file compiled you would end up with this;

    public interface IConfigurations
    {
        string Key1 { get; }
        string Key2 { get; }
    }

    public class Configurations : IConfigurations
    {
        public string Key1
        {
            get
            {
                return "value1";
            }
        }
        public string Key2
        {
            get
            {
                return "value2";
            }
        }
    }

Same goes for connection strings as well!

##Install
Can be install from Nuget as well;

    Install-Package T4Config

## How do I do it?
- Copy the Configurations.tt file from the src directory to your project.
- Update the configFile value to the proper config file (web or app).
- Right click on the file and click "Run Custom Tool".

Enjoy!
