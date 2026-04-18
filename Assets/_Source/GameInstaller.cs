using UnityEngine;
using Zenject;

namespace _Source
{
    public class GameInstaller : MonoInstaller
    {
        private enum SaveImplementation { PlayerPrefs, Json }
        
        [SerializeField] private SaveImplementation currentImplementation = SaveImplementation.Json;
        
        public override void InstallBindings()
        {
            BindSaveSystem();
        }

        private void BindSaveSystem()
        {
            switch (currentImplementation)
            {
                case SaveImplementation.PlayerPrefs:
                    Container.Bind<ISaveSystem>().To<PlayerPrefsSaveSystem>().AsSingle();
                    break;
                case SaveImplementation.Json:
                    Container.Bind<ISaveSystem>().To<JsonSaveSystem>().AsSingle();
                    break;
            }
        }
    }
}