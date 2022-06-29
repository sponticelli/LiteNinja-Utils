using UnityEngine;

namespace LiteNinja.Utils
{
	/// <summary>
	/// A scoped PlayerPrefs - useful for storing values separating them by context (e.g a game, a level, or different users)
	/// </summary>
	public class ScopedPlayerPrefs : IPlayerPrefs
	{
		private const string ScopeKeySeparator = "__";

		public void SetInt(string scope, string key, int val)
		{
			PlayerPrefs.SetInt(Key(scope, key), val);
		}

		public int GetInt(string scope, string key, int defaultValue = 0)
		{
			return PlayerPrefs.GetInt(Key(scope, key), defaultValue);
		}

		public void SetBool(string scope, string key, bool val)
		{
			PlayerPrefs.SetInt(Key(scope, key), val ? 1 : 0);
		}

		public bool GetBool(string scope, string key, bool defaultValue = false)
		{
			return PlayerPrefs.GetInt(Key(scope, key), (defaultValue ? 1 : 0)) == 1;
		}

		public void SetFloat(string scope, string key, float val)
		{
			PlayerPrefs.SetFloat(Key(scope, key), val);
		}

		public float GetFloat(string scope, string key, float defaultValue = 0.0f)
		{
			return PlayerPrefs.GetFloat(Key(scope, key), defaultValue);
		}

		public void SetString(string scope, string key, string value)
		{
			PlayerPrefs.SetString(Key(scope, key), value);
		}

		public string GetString(string scope, string key, string defaultValue = "")
		{
			return PlayerPrefs.GetString(Key(scope, key), defaultValue);
		}

		public bool HasKey(string scope, string key)
		{
			return PlayerPrefs.HasKey(Key(scope, key));
		}

		private string Key(string scope, string key)
		{
			return scope + ScopeKeySeparator + key;
		}

		public void SetIntArray(string scope, string key, int[] values)
		{
			PlayerPrefs.SetString(Key(scope, key), JsonUtility.ToJson(values));
		}

		public int[] GetIntArray(string scope, string key)
		{
			var str = PlayerPrefs.GetString(Key(scope, key));
			var values = JsonUtility.FromJson<int[]>(str);
			return values;
		}

		public void SetFloatArray(string scope, string key, float[] values)
		{
			PlayerPrefs.SetString(Key(scope, key), JsonUtility.ToJson(values));
		}

		public float[] GetFloatArray(string scope, string key)
		{
			var str = PlayerPrefs.GetString(Key(scope, key));
			var values = JsonUtility.FromJson<float[]>(str);
			return values;
		}

		public void SetBoolArray(string scope, string key, bool[] values)
		{
			PlayerPrefs.SetString(Key(scope, key), JsonUtility.ToJson(values));
		}

		public bool[] GetBoolArray(string scope, string key)
		{
			var str = PlayerPrefs.GetString(Key(scope, key));
			var values = JsonUtility.FromJson<bool[]>(str);
			return values;
		}

		public void SetStringArray(string scope, string key, string[] values)
		{
			PlayerPrefs.SetString(Key(scope, key), JsonUtility.ToJson(values));
		}

		public string[] GetStringArray(string scope, string key)
		{
			var str = PlayerPrefs.GetString(Key(scope, key));
			var values = JsonUtility.FromJson<string[]>(str);
			return values;
		}
		

		public void DeleteArray(string scope, string key)
		{
			PlayerPrefs.DeleteKey(Key(scope, key));
		}

		public void DeleteAll()
		{
			PlayerPrefs.DeleteAll();
		}

		public void Save()
		{
			PlayerPrefs.Save();
		}

	}
}