using Core.EventChannels;
using UnityEngine.AddressableAssets;

namespace Core.Addressable_Extensions
{
    [System.Serializable]
    public class AssetReferenceEventChannel : AssetReferenceT<EventChannelBase>
    {

        public AssetReferenceEventChannel(string guid) : base(guid)
        {
        }
    }

}
