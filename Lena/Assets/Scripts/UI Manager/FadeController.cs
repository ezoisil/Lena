using Core.EventChannels;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UI_Manager
{

    public class FadeController : MonoBehaviour
    {
        [SerializeField] private FadeEventChannel _fadeEventChannel;
        [SerializeField] private Image _fadeImage; 
        private void OnEnable()
        {
            _fadeEventChannel.OnEventRaised += InitiateFade;
        }

        private void InitiateFade(bool fadeIn, float duration)
        {
            _fadeImage.material.DOFade(fadeIn ? 1 : 0, duration);
        }
    }

}
