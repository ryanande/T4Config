

namespace T4Config
{
    public interface IConfigurations
    {
        string Key1 { get; }
        string Key2 { get; }
        string Key3 { get; }
        string Key4 { get; }
        string Key5 { get; }
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
        public string Key3
        {
            get
            {
                return "value3";
            }
        }
        public string Key4
        {
            get
            {
                return "value4";
            }
        }
        public string Key5
        {
            get
            {
                return "value5";
            }
        }
    }
}

