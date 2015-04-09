using System;
using System.Configuration;

namespace T4Config
{
	public interface IConfigurations
	{
		string Key1 { get; }
		Guid Key2 { get; }
		int Key3 { get; }
		bool Key4 { get; }
	}

	public class Configurations : IConfigurations
	{
		private static readonly Lazy<string> _key1 = new Lazy<string>(() => 
				 ConfigurationManager.AppSettings["Key1"]
	);
		private static readonly Lazy<Guid> _key2 = new Lazy<Guid>(() => 
				 new Guid(ConfigurationManager.AppSettings["Key2"])
	);
		private static readonly Lazy<int> _key3 = new Lazy<int>(() => 
				 Convert.ToInt32(ConfigurationManager.AppSettings["Key3"])
	);
		private static readonly Lazy<bool> _key4 = new Lazy<bool>(() => 
				 Convert.ToBoolean(ConfigurationManager.AppSettings["Key4"])
	);

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
}

