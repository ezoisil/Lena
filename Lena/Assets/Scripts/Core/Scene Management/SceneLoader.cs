using System;
using Core.EventChannels;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

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

        [Header("Broadcasting on")]
        [SerializeField] private BoolEventChannel _toggleLoadingScreen;
        [SerializeField] private VoidEventChannel _onSceneReady;
        [SerializeField] private FadeEventChannel _fadeRequestChannel;

        private AsyncOperationHandle<SceneInstance> _loadingOperationHandle;
        private AsyncOperationHandle<SceneInstance> _gameplayManagerLoadingOperationHandle;

        private GameScene _sceneToLoad;
        private GameScene _currentlyLoadedScene;
        private bool _showLoadingScreen;

        private SceneInstance _gameplayManagerSceneInstance;
        private bool _isLoading = false;

        private void OnEnable()
        {
            _loadLocation.OnLoadingRequested += LoadLocation;
            _loadMainMenu.OnLoadingRequested += LoadMainMenu;
        }

        private void LoadMainMenu(GameScene arg0, bool arg1, bool arg2)
        {
            throw new NotImplementedException();
        }

        private void LoadLocation(GameScene arg0, bool arg1, bool arg2)
        {
            throw new NotImplementedException();
        }
    }

}
