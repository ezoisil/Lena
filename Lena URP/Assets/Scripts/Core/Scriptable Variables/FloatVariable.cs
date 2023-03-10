using System;
using UnityEngine;

namespace Core.Scriptable_Variables
{

    [CreateAssetMenu(menuName = "Float Variable")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float _value;
        public Action OnValueChanged;

        public float GetValue()
        {
            return _value;
        }

        public void ChangeValue(float value)
        {
            _value = value;
            OnValueChanged?.Invoke();
        }
        
        
        
    }

}
