using UnityEngine;
using System.IO;

public class SaveSystem
{
   //セーブ
   public static void Save(in object instance, string PATH, bool overWrite = false) {
       string jsonstr = JsonUtility.ToJson(instance);
       var writer = new StreamWriter(PATH, overWrite);
       writer.Write(jsonstr);
       writer.Flush();
       writer.Close();
       Debug.Log("Saved!");
   }

   //ロード
   public static string Load(string PATH) {
       var reader = new StreamReader(PATH);
       string json = reader.ReadToEnd();
       reader.Close();
       Debug.Log("Loaded!");
       return json;
   }
}