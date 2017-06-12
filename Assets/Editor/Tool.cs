using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Babybus.Framework.ExtensionMethods; 

class Tool
{
	[System.Serializable]
	class Download
	{
		[System.Serializable]
		public class Detail 
		{
			public string url;
			public string key;
		}

		public Detail download;
	}

	//从 /Users/laishencan/Library/Unity/Asset Store-5.x/ 中找到 .Survival Shooter tutorial-content__40756.tmp.json
	//从 json 中 提取 url, key
	//用 其他下载工具下载 url, 得到 未解析的插件文件
	//用 反射 UnityEditor.AssetStoreUtils.DecryptFile 解析 插件文件

	public static void DecryptUnityPackage(string inputFile, string key)
	{
        System.Reflection.Assembly unityEditor = typeof(Editor).Assembly;  
  
        System.Type assetStoreUtils = unityEditor.GetType("UnityEditor.AssetStoreUtils");  
  
        assetStoreUtils.Invoke("DecryptFile", inputFile, inputFile + ".unitypackage", key);  
	}

	public static string GetUrl(string jsonFilePath)
	{
		string json = System.IO.File.ReadAllText(jsonFilePath);
		Download downloadInfo = JsonUtility.FromJson<Download>(json);

		string url = downloadInfo.download.url;

		return url;
	}

	public static string GetKey(string jsonFilePath)
	{
		string json = System.IO.File.ReadAllText(jsonFilePath);
		Download downloadInfo = JsonUtility.FromJson<Download>(json);

		string key = downloadInfo.download.key;

		return key;
	}

	public static void DownloadUrl(string url)
	{
	}
}