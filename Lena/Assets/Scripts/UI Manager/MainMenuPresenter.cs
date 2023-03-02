using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI_Toolkit.Panels
{

    public class MainMenuPresenter : MonoBehaviour
    {
        [SerializeField] private VisualElement _rootVisualElement;

        private Button _startButton;
        private Button _settingsButton;
        private Button _quitButton;

        private void Awake()
        {
            _startButton = _rootVisualElement.Q<Button>("Start");
            _settingsButton = _rootVisualElement.Q<Button>("Settings");
            _quitButton = _rootVisualElement.Q<Button>("Quit");
        }
        

        private void OnEnable()
        {
            _startButton.clicked += OnStartButtonClicked;
            _settingsButton.clicked += OnSettingsButtonClicked;
            _quitButton.clicked += OnQuitButtonClicked;
        }

        private void OnDestroy()
        {
            _startButton.clicked -= OnStartButtonClicked;
            _settingsButton.clicked -= OnSettingsButtonClicked;
            _quitButton.clicked -= OnQuitButtonClicked;
        }

        #region Button Event Listeners

        private void OnStartButtonClicked()
        {
            
        }
        
        private void OnSettingsButtonClicked()
        {
            
        }
        
        private void OnQuitButtonClicked()
        {
            Application.Quit();
        }

        #endregion
    }

}
