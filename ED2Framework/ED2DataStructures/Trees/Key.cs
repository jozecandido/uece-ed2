using System;
using System.Text.RegularExpressions;

namespace ED2DataStructures.Trees
{
	/// <summary>
	/// Summary description for KEY.
	/// </summary>
	public class Key
	{
		private const string pattern = "[A-a]";
		private string keyValue;
		public string VALUE
		{
			get
			{
				return keyValue;
			}
			set
			{
				if(Regex.IsMatch(value,""))
					keyValue = value;
			}
		}

		public Key()
		{
			this.keyValue = "1";
		}

		public Key(string keyValue)
		{
			this.keyValue = keyValue;
		}

		public static bool match(string key)
		{
			if(Regex.IsMatch(key,pattern))
				return true;
			else 
				return false;
		}
	}
}
