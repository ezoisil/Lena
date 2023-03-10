using System;
using System.Collections.Generic;
using Core.Scriptable_Variables;
using UnityEngine;

namespace UI
{
    public class HealthBarHUD : MonoBehaviour
    {
        [SerializeField] private FloatVariable _playerMaxHealth;
        [SerializeField] private FloatVariable _playerCurrentHealth;

        private GameObject[] _healthTicks = new GameObject[10];

        private void Awake()
        {
            _healthTicks = transform.GetComponentsInChildren<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                _healthTicks[i] = transform.GetChild(i).gameObject;
            }
        }

        private void OnEnable()
        {
            _playerMaxHealth.OnValueChanged += UpdateHUD;
            _playerCurrentHealth.OnValueChanged += UpdateHUD;
        }

        private void OnDisable()
        {
            _playerMaxHealth.OnValueChanged -= UpdateHUD;
            _playerCurrentHealth.OnValueChanged -= UpdateHUD;
        }


        private void UpdateHUD(float amountChange)
        {
            if(amountChange < 0)
                Destroy(transform.GetChild(0).gameObject);
        }
    }

}
