using System;

namespace _Source
{
    [Serializable]
    public class GameData
    {
        public float score;
        public float playTime;
    }

    public interface ISaveSystem
    {
        void Save(GameData data);
        GameData Load();
    }
}