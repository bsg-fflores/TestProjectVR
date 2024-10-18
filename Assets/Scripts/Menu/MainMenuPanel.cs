using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MainMenuPanel : MenuPanel
    {
        public Button startButton;
        public Button settingsButton;
        public Button exitButton;

        private void OnEnable()
        {
            startButton.onClick.AddListener(_menuMediator.OnStartButtonClicked);
            settingsButton.onClick.AddListener(_menuMediator.OnSettingsButtonClicked);
            exitButton.onClick.AddListener(_menuMediator.OnExitButtonClicked);
        }
        
        private void OnDisable()
        {
            startButton.onClick.RemoveListener(_menuMediator.OnStartButtonClicked);
            settingsButton.onClick.RemoveListener(_menuMediator.OnSettingsButtonClicked);
            exitButton.onClick.RemoveListener(_menuMediator.OnExitButtonClicked);
        }
        
        public override void Show()
        {
            
        }

        public override void Hide()
        {
            
        }
    }
}