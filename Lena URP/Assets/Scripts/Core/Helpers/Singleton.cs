using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts._Helpers
{

    [DisallowMultipleComponent]
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T i;

        public static T I
        {
            get
            {
#if UNITY_EDITOR
                if (Application.isPlaying == false)
                    if (i == null)
                        i = (T) FindObjectOfType(typeof(T));
#endif
                return i;
            }

            protected set
            {
                i = value;
            }
        }

        protected virtual void Awake()
        {
            if (I != null && I != this)
            {
                Destroy(this);
            }
            else
            {
                I = this as T;
            }
        }
    }


}