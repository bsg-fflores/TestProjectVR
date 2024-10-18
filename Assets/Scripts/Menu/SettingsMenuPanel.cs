using UnityEngine.UI;

namespace Menu
{
    public class SettingsMenuPanel : MenuPanel
    {
        public Slider volumeSlider;
        public Button backButton;
        
        private void OnEnable()
        {
            volumeSlider.onValueChanged.AddListener(_menuMediator.OnVolumeSliderValueChanged);
            backButton.onClick.AddListener(_menuMediator.OnBackButtonClicked);
        }
        
        public override void Show()
        {
            throw new System.NotImplementedException();
        }

        public override void Hide()
        {
            throw new System.NotImplementedException();
        }
    }
}