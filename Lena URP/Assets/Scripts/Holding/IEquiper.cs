using UnityEngine;

namespace Holding
{

    public interface IEquiper
    {
        public Transform HoldTransform { get; }
        public IEquipment CurrentEquipment { get; }
        public void Equip(IEquipment equipment);
        public void Unequip(IEquipment equipment);
        public void Give(IEquipment equipment);
    }

}
