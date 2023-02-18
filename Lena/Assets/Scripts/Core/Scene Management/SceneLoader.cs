using System.Collections;
using Core.EventChannels;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Core.Scene_Management
{

    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private GameScene _gameplayScene;
        [SerializeField] private InputReader _inputReader;

        [Header("Loading Settings")]
        [SerializeField] private float _fadeDuration = .5f;

        [Header("Listening to")]
        [SerializeField] private LoadEventChannel _loadLocation;
        [SerializeField] private LoadEventChannel _loadMainMenu;
        [SerializeField] private LoadEventChannel _coldStartupLocation = default;


        [Header("Broadcasting on")]
        [SerializeField] private BoolEventChannel _toggleLoadingScreen;
        [SerializeField] private VoidEventChannel _onSceneReady;
        [SerializeField] private FadeEventChannel _fadeRequestChannel;

        private AsyncOperationHandle<SceneInstance> _loadingOperationHandle;
        private AsyncOperationHandle<SceneInstance> _gameplayManagerLoadingOperationHandle;

        private GameScene _currentlyLoadedScene;
        private SceneLoadingSettings _sceneLoadingSettings;

        private SceneInstance _gameplayManagerSceneInstance;
        private bool _isLoading = false;

        private void OnEnable()
        {
            _loadLocation.OnLoadingRequested += TryChangeScene;
            _loadMainMenu.OnLoadingRequested += TryChangeScene;
#if UNITY_EDITOR
            _coldStartupLocation.OnLoadingRequested += LocationColdStartup;
#endif
        }

#if UNITY_EDITOR
        /// <summary>
        /// This special loading function is only used in the editor, when the developer presses Play in a Location scene, without passing by Initialisation.
        /// </summary>
        private void LocationColdStartup(SceneLoadingSettings sceneLoadingSettings)
        {
            _currentlyLoadedScene = sceneLoadingSettings.SceneToLoad;

            if (_currentlyLoadedScene.SceneType == GameSceneType.Location)
            {
                //Gameplay managers is loaded synchronously
                _gameplayManagerLoadingOperationHandle = _gameplayScene.SceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
                _gameplayManagerLoadingOperationHandle.WaitForCompletion();
                _gameplayManagerSceneInstance = _gameplayManagerLoadingOperationHandle.Result;

                SceneReady();
            }
        }
#endif

        private void TryChangeScene(SceneLoadingSettings sceneLoadingSettings)
        {
            if (!CanChangeScene()) return;
            _isLoading = true;
            _sceneLoadingSettings = sceneLoadingSettings;

            switch (sceneLoadingSettings.GameSceneType)
            {
                case GameSceneType.Menu:

                    if (IsGameManagerLoaded())
                        Addressables.UnloadSceneAsync(_gameplayManagerLoadingOperationHandle, true);
                    StartCoroutine(ChangeSceneCoroutine());
                    break;

                case GameSceneType.Location:

                    if (!IsGameManagerLoaded())
                    {
                        _gameplayManagerLoadingOperationHandle =
                            _gameplayScene.SceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
                        _gameplayManagerLoadingOperationHandle.Completed += OnGameplayManagersLoaded;
                    }
                    else
                    {
                        StartCoroutine(ChangeSceneCoroutine());
                    }
                    break;
            }
        }


        private bool IsGameManagerLoaded()
        {
            // TODO: check this
            return _gameplayManagerSceneInstance.Scene == null
                   || !_gameplayManagerSceneInstance.Scene.isLoaded;
        }

        private bool CanChangeScene()
        {
            if (_isLoading) return false;

            return true;
        }

        private IEnumerator ChangeSceneCoroutine()
        {
            _inputReader.DisableAllInput();
            _fadeRequestChannel.FadeOut(_fadeDuration);

            yield return new WaitForSeconds(_fadeDuration);

            UnloadCurrentScene();

            LoadNewScene();
        }

        private void UnloadCurrentScene()
        {
            if (_currentlyLoadedScene == null) return;
            if (_currentlyLoadedScene.SceneReference.OperationHandle.IsValid())
            {
                //Unload the scene through its AssetReference, i.e. through the Addressable system
                _currentlyLoadedScene.SceneReference.UnLoadScene();
            }
#if UNITY_EDITOR
            else
            {
                //Only used when, after a "cold start", the player moves to a new scene
                //Since the AsyncOperationHandle has not been used (the scene was already open in the editor),
                //the scene needs to be unloaded using regular SceneManager instead of as an Addressable
                SceneManager.UnloadSceneAsync(_currentlyLoadedScene.SceneReference.editorAsset.name);
            }
#endif
        }

        private void LoadNewScene()
        {
            if (_sceneLoadingSettings.ShowLoadingScreen)
            {
                _toggleLoadingScreen.RaiseEvent(true);
            }

            _loadingOperationHandle = _sceneLoadingSettings.SceneToLoad.SceneReference.LoadSceneAsync(LoadSceneMode.Additive, true, 0);
            _loadingOperationHandle.Completed += OnNewSceneLoaded;
        }

        private void SceneReady()
        {
            _onSceneReady.RaiseEvent(); //Spawn system will spawn the PigChef in a gameplay scene
        }


        #region Event Listeners

        private void OnGameplayManagersLoaded(AsyncOperationHandle<SceneInstance> obj)
        {
            _gameplayManagerSceneInstance = _gameplayManagerLoadingOperationHandle.Result;

            StartCoroutine(ChangeSceneCoroutine());
        }

        private void OnNewSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
        {
            //Save loaded scenes (to be unloaded at next load request)
            _currentlyLoadedScene = _sceneLoadingSettings.SceneToLoad;

            Scene s = obj.Result.Scene;
            SceneManager.SetActiveScene(s);
            LightProbes.TetrahedralizeAsync();

            _isLoading = false;

            if (_sceneLoadingSettings.SceneToLoad)
                _toggleLoadingScreen.RaiseEvent(false);

            _fadeRequestChannel.FadeIn(_fadeDuration);

            SceneReady();
        }

        #endregion


    }

}
