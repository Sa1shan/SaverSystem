using UnityEngine;
using System.IO;

namespace _Source
{
    public class JsonSaveSystem : ISaveSystem
    {
        private string _filePath;

        public JsonSaveSystem()
        {
            _filePath = Path.Combine(Application.persistentDataPath, "gamedata.json");
        }

        public void Save(GameData data)
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(_filePath, json);
        }

        public GameData Load()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                return JsonUtility.FromJson<GameData>(json);
            }
            return new GameData();
        }
    }
}