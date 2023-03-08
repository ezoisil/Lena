using Core.Addressable_Extensions;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Scene_Management
{
    /// <summary>
    /// Holds data regarding to specified scene.
    /// </summary>
    [CreateAssetMenu(menuName = "Scene Management/Game Scene")]
 
    public class GameScene : ScriptableObject
    {
        public GameSceneType SceneType;
        /// <summary>
        /// Can be used for loading or unloading a scene.
        /// </summary>
        public AssetReference SceneReference;
    }

}
