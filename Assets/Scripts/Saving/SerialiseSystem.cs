using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UI;
using UnityEngine;

namespace Saving{
    public static class SerialiseSystem
    {
    
        public static void SaveData (SettingsScript settingsScript)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/settingsData.did";
            Debug.Log(path);
            FileStream stream = new FileStream(path, FileMode.Create);
        
            SaveData data = new SaveData(settingsScript);
        
            formatter.Serialize(stream, data);
            stream.Close();
        }
    
        public static SaveData LoadData()
        {
            string path = Application.persistentDataPath + "/settingsData.did";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
            
                SaveData data = formatter.Deserialize(stream) as SaveData;
                stream.Close();
            
                return data;
            }else
            {
                Debug.Log($"Save file not found in {path}");
                return null;
            }
        }
    }
}
