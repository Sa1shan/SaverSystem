using UnityEngine;
using System.IO;

namespace _Source
{
    public class PlayerPrefsSaveSystem : ISaveSystem
    {
        private const string SaveKey = "GameDataSave";

        public void Save(GameData data)
        {
            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(SaveKey, json);
            PlayerPrefs.Save();
        }

        public GameData Load()
        {
            if (PlayerPrefs.HasKey(SaveKey))
            {
                string json = PlayerPrefs.GetString(SaveKey);
                return JsonUtility.FromJson<GameData>(json);
            }
            return new GameData();
        }
    }
}