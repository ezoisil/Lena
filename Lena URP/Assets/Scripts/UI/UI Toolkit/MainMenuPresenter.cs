using Core.EventChannels;
using Core.Scene_Management;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI_Manager
{

    public class MainMenuPresenter : MonoBehaviour
    {
        [SerializeField] private LoadEventChannel _locationLoadEventChannel;
        [SerializeField] private GameScene _sceneToLoad;
        
        private VisualElement _rootVisualElement;
        private UIDocument _uiDocument;
        
        private Button _startButton;
        private Button _settingsButton;
        private Button _quitButton;

        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            _rootVisualElement = _uiDocument.rootVisualElement;
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

        private void OnDisable()
        {
            _startButton.clicked -= OnStartButtonClicked;
            _settingsButton.clicked -= OnSettingsButtonClicked;
            _quitButton.clicked -= OnQuitButtonClicked;
        }

        #region Button Event Listeners

        private void OnStartButtonClicked()
        {
            SceneLoadingSettings sceneLoadingSettings = new SceneLoadingSettings(_sceneToLoad, true, true);
            _locationLoadEventChannel.RaiseEvent(sceneLoadingSettings);
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
