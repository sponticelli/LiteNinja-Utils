namespace LiteNinja.Utils
{
    public interface IPlayerPrefs
    {
        void SetInt(string scope, string key, int val);
        int GetInt(string scope, string key, int defaultValue = 0);
        void SetBool(string scope, string key, bool val);
        bool GetBool(string scope, string key, bool defaultValue = false);
        void SetFloat(string scope, string key, float val);
        float GetFloat(string scope, string key, float defaultValue = 0.0f);
        void SetString(string scope, string key, string value);
        string GetString(string scope, string key, string defaultValue = "");
        bool HasKey(string scope, string key);
        void SetIntArray(string scope, string key, int[] values);
        int[] GetIntArray(string scope, string key);
        void SetFloatArray(string scope, string key, float[] values);
        float[] GetFloatArray(string scope, string key);
        void SetBoolArray(string scope, string key, bool[] values);
        bool[] GetBoolArray(string scope, string key);
        void SetStringArray(string scope, string key, string[] values);
        string[] GetStringArray(string scope, string key);
        void DeleteArray(string scope, string key);
        void DeleteAll();
        void Save();
    }
}