using System;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class MenuMediator : MonoBehaviour
    {
        [SerializeField] private MainMenuPanel _mainMenuPanel;
        [SerializeField] private SettingsMenuPanel _settingsMenuPanel;
        private Stack<MenuPanel> _menuPanels = new Stack<MenuPanel>();

        private void Awake()
        {
            _mainMenuPanel.Config(this);
            
            _menuPanels.Push(_mainMenuPanel);
        }

        public void OnStartButtonClicked()
        {
            
        }

        public void OnSettingsButtonClicked()
        {
            _menuPanels.Push(_settingsMenuPanel);
            _menuPanels.Peek().Hide();
            _settingsMenuPanel.Show();
        }

        public void OnExitButtonClicked()
        {
            throw new System.NotImplementedException();
        }

        public void OnVolumeSliderValueChanged(float arg0)
        {
            throw new NotImplementedException();
        }

        public void OnBackButtonClicked()
        {
            _menuPanels.Pop().Hide();
        }
    }
}