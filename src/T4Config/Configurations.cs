
#pragma warning disable 1591, 3008, 3009

namespace T4Config
{
    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed.")]
    public interface IConfigurations
    {
        string Key1 { get; }

        Guid Key2 { get; }

        int Key3 { get; }

        bool Key4 { get; }

    }

    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]
    public class Configurations : IConfigurations
    {
        private static readonly Lazy<string> _key1 = new Lazy<string>(() => GetSetting("Key1"));

        private static readonly Lazy<Guid> _key2 = new Lazy<Guid>(() => new Guid(GetSetting("Key2")));

        private static readonly Lazy<int> _key3 = new Lazy<int>(() => Convert.ToInt32(GetSetting("Key3")));

        private static readonly Lazy<bool> _key4 = new Lazy<bool>(() => Convert.ToBoolean(GetSetting("Key4")));


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


        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }

    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed.")]
    public interface IConnectionStrings
    {
        string LocalSqlServer { get; }
    }

    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]
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

#pragma warning restore 1591, 3008, 3009
