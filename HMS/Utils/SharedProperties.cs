namespace HMS.Utils
{
    public class SharedProperties
    {


        public string GetString(string key)
        {

            if (App.Current.Properties.ContainsKey(key))
            {
                return (string)App.Current.Properties[key];
            }
            return "";
        }

        public void SetString(string key, string value)
        {
            App.Current.Properties[key] = value;
        }

        public int GetInt(string key)
        {
            if (App.Current.Properties.ContainsKey(key))
            {
                return (int)App.Current.Properties[key];
            }
            return 0;
        }

        public void SetInt(string key, int value)
        {
            App.Current.Properties[key] = value;
        }

        public long GetLong(string key)
        {

            if (App.Current.Properties.ContainsKey(key))
            {
                return (long)App.Current.Properties[key];
            }
            return 0;
        }

        public void SetLong(string key, long value)
        {
            App.Current.Properties[key] = value;
        }

        public bool GetBool(string key)
        {

            if (App.Current.Properties.ContainsKey(key))
            {
                return (bool)App.Current.Properties[key];
            }
            return false;
        }

        public void SetBool(string key, bool value)
        {
            App.Current.Properties[key] = value;
        }


    }
}
