using Core.EventChannels;
using UnityEngine.AddressableAssets;

namespace Core.Addressable_Extensions
{
    [System.Serializable]
    public class AssetReferenceScene : AssetReferenceT<EventChannelBase>
    {

        public AssetReferenceScene(string guid) : base(guid)
        {
        }
    }

}
