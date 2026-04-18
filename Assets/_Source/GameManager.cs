using UnityEngine;
using TMPro;
using Zenject;

namespace _Source
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float points = 10f;
        [SerializeField] private ClickableButton clickButton;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI timeText;

        private ISaveSystem _saveSystem;
        private GameData _currentData;
        
        [Inject]
        public void Construct(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        private void Start()
        {
            LoadGame();
        }

        private void OnEnable()
        {
            clickButton.OnButton += HandleButton;
        }

        private void OnDisable()
        {
            clickButton.OnButton -= HandleButton;
        }

        private void Update()
        {
            _currentData.playTime += Time.deltaTime;
            UpdateUI();
        }

        private void HandleButton(float holdClick)
        {
            float point = points * holdClick;
            _currentData.score += point;

            SaveGame();
            UpdateUI();
        }

        private void UpdateUI()
        {
            scoreText.text = $"Score: {_currentData.score:F1}";

            int minutes = Mathf.FloorToInt(_currentData.playTime / 60F);
            int seconds = Mathf.FloorToInt(_currentData.playTime - minutes * 60);
            timeText.text = $"Time: {minutes:00}:{seconds:00}";
        }

        private void SaveGame()
        {
            _saveSystem.Save(_currentData);
        }

        private void LoadGame()
        {
            _currentData = _saveSystem.Load();
            UpdateUI();
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }
    }
}    