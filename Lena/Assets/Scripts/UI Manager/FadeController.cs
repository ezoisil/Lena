using System;
using Core.EventChannels;
using UnityEngine;
using UnityEngine.UI;

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

        private void InitiateFade(bool fadeIn, float duration, Color color)
        {
            
        }
    }

}
