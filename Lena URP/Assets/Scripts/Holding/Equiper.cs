using System;
using System.Collections.Generic;
using UnityEngine;

namespace Holding
{

    public class Equiper : IEquiper
    {
        public List<Transform> HoldTransforms;
        public List<Equipment> CurrentEquipments;
        public void Equip(Equipment equipment)
        {
            throw new System.NotImplementedException();
        }

        public void Unequip(Equipment equipment)
        {
            throw new System.NotImplementedException();
        }

        public void Give(Equipment equipment)
        {
            throw new System.NotImplementedException();
        }
    }

}
