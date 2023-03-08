using UnityEngine;

namespace Save_System
{

    public interface ISaveable
    {
        public void Save();

        public void Load();
    }

}
