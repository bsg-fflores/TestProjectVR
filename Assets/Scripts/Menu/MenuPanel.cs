using UnityEngine;

namespace Menu
{
    public abstract class MenuPanel : MonoBehaviour
    {
        protected MenuMediator _menuMediator;
        
        public void Config(MenuMediator pMenuMediator)
        {
            _menuMediator = pMenuMediator;
        }
        public abstract void Show();
        public abstract void Hide();
    }
}