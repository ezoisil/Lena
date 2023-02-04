using Core.EventChannels;
using UnityEngine.AddressableAssets;

namespace Core.AddressableExtensions
{
    [System.Serializable]
    public class AssetReferenceEventChannel : AssetReferenceT<EventChannelBase>
    {

        public AssetReferenceEventChannel(string guid) : base(guid)
        {
        }
    }

}
