namespace LiteNinja.Utils
{
    /// <summary>
    /// static class for ScopedPlayerPrefs
    /// </summary>
    public static class GlobalPlayerPrefs
    {
        private static IPlayerPrefs _instance;
        private static IPlayerPrefs Instance => _instance ??= new ScopedPlayerPrefs();


        public static void SetInt(string key, int val)
        {
            Instance.SetInt(string.Empty, key, val);
        }

        public static int GetInt(string key, int defaultValue = 0)
        {
            return Instance.GetInt(string.Empty, key, defaultValue);
        }

        public static void SetBool(string key, bool val)
        {
            Instance.SetBool(string.Empty, key, val);
        }

        public static bool GetBool(string key, bool defaultValue = false)
        {
            return Instance.GetBool(string.Empty, key, defaultValue);
        }

        public static void SetFloat(string key, float val)
        {
            Instance.SetFloat(string.Empty, key, val);
        }

        public static float GetFloat(string key, float defaultValue = 0.0f)
        {
            return Instance.GetFloat(string.Empty, key, defaultValue);
        }

        public static void SetString(string key, string value)
        {
            Instance.SetString(string.Empty, key, value);
        }

        public static string GetString(string key, string defaultValue = "")
        {
            return Instance.GetString(string.Empty, key, defaultValue);
        }

        public static bool HasKey(string key)
        {
            return Instance.HasKey(string.Empty, key);
        }

        public static void SetIntArray(string key, int[] values)
        {
            Instance.SetIntArray(string.Empty, key, values);
        }

        public static int[] GetIntArray(string key)
        {
            return Instance.GetIntArray(string.Empty, key);
        }

        public static void SetFloatArray(string key, float[] values)
        {
            Instance.SetFloatArray(string.Empty, key, values);
        }

        public static float[] GetFloatArray(string key)
        {
            return Instance.GetFloatArray(string.Empty, key);
        }

        public static void SetBoolArray(string key, bool[] values)
        {
            Instance.SetBoolArray(string.Empty, key, values);
        }

        public static bool[] GetBoolArray(string key)
        {
            return Instance.GetBoolArray(string.Empty, key);
        }

        public static void SetStringArray(string key, string[] values)
        {
            Instance.SetStringArray(string.Empty, key, values);
        }

        public static string[] GetStringArray(string key)
        {
            return Instance.GetStringArray(string.Empty, key);
        }

        public static void DeleteArray(string key)
        {
            Instance.DeleteArray(string.Empty, key);
        }

        public static void DeleteAll()
        {
            Instance.DeleteAll();
        }

        public static void Save()
        {
            Instance.Save();
        }
    }
}