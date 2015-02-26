using System;
using System.Configuration;

namespace T4Config
{
    public interface IConfigurations
    {
        string Key1 { get; }
        Guid Key2 { get; }
        int Key3 { get; }
    }

    public class Configurations : IConfigurations
    {
        public string Key1
        {
            get
            {
                return ConfigurationManager.AppSettings["Key1"];
            }
        }
        public Guid Key2
        {
            get
            {
                return new Guid(ConfigurationManager.AppSettings["Key2"]);
            }
        }
        public int Key3
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["Key3"]);
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
                return ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            }
        }
    }
}

