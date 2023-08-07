using System;
using Core.EventChannels;
using Holding;
using Scriptable_Variables;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform _rHandTransform;
        [SerializeField] private Transform _lHandTransform;
      

        [SerializeField] private Vector3Variable _playerPosition;
        [SerializeField] private InputReader _inputReader;

        private void OnEnable()
        {
            _inputReader.PrimaryAttackEvent += OnPrimaryAttack;
            _inputReader.EnableGameInput();
        }

        private void OnDisable()
        {
            _inputReader.PrimaryAttackEvent -= OnPrimaryAttack;
        }
        
        private void Update()
        {
            _playerPosition.Value = transform.position;
        }

        private void OnPrimaryAttack()
        {
            
        }

    }

}
