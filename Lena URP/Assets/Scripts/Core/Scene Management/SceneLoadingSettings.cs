using System;

namespace Core.Scene_Management
{
    [Serializable]
    public class SceneLoadingSettings
    {
        public GameScene SceneToLoad { get; private set; }
        public bool ShowLoadingScreen { get; private set; }
        public bool FadeScreen { get; private set; }

        public SceneLoadingSettings(GameScene sceneToLoad, bool showLoadingScreen, 
            bool fadeScreen)
        {
            SceneToLoad = sceneToLoad;
            ShowLoadingScreen = showLoadingScreen;
            FadeScreen = fadeScreen;
        }
    }

}
