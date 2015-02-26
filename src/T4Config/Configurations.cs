

namespace T4Config
{
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

		public interface IConnectionStrings
	{
				string LocalSqlServer { get; }
		}

	public class ConnectionStrings : IConnectionStrings
	{
				public string LocalSqlServer 
		{
			get 
			{
				return @"data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true";
			}
		}
		}
	}

