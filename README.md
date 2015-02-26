# T4Config

A down and dirty way to have strongly typed App Settings and Connection Strings using T4.

In a nutshell we create an interface called IConfigurations, so you can do all your fancy DI/IoC stuff, and a concrete implementation called Configurations. (both names totally customizable.

The T4 template loops through the web.config or app.config appSettings and generates a read only property for each key and returns the values placed in the settings value.

Enjoy!
