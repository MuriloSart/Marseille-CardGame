using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities.LifeCycle.Death
{
    public class Death : MonoBehaviour,  IDeath
    {
        [SerializeField]private int screen = 3;
        
        public bool canDie = true;

        public int Screen
        {
            get { return screen; }
            set 
            { 
                if (value != 3 || value != 4) return;
                else screen = value;
            }
        }

        public virtual void OnDeath()
        {
            if (canDie)
                SceneManager.LoadScene(screen);
        }
    }
}
