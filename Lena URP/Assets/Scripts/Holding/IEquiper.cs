using UnityEngine;

namespace Holding
{

    public interface IEquiper
    {
   
        public void Equip(Equipment equipment);
        public void Unequip(Equipment equipment);
        public void Give(Equipment equipment);
    }

}
