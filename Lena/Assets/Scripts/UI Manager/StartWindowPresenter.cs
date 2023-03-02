using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI_Manager
{

    public class StartWindowPresenter : MonoBehaviour
    {
        private VisualElement _root;
        private VisualElement _settingsWindow;
        private VisualElement _mainMenuWindow;

        private void Start()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _mainMenuWindow = _root.Q<VisualElement>("MainMenuWindow");
            _settingsWindow = _root.Q<VisualElement>("SettingsWindow");
        }
    }

}
