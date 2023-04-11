using System;
using UnityEngine;

namespace Holding
{

    public class Equiper : IEquiper
    {
        [SerializeField] protected Transform _equipTransform;
        [SerializeField] protected IEquipment _currentEquipment;
        
        public Transform HoldTransform { get => _equipTransform; }
        public IEquipment CurrentEquipment { get => _currentEquipment; }

        public void Equip(IEquipment equipment)
        {
            equipment
        }

        public void Unequip(IEquipment equipment)
        {
            throw new System.NotImplementedException();
        }

        public void Give(IEquipment equipment)
        {
            throw new System.NotImplementedException();
        }
    }

}
