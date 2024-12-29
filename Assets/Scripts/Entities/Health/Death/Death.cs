using UnityEngine;
public class Death : MonoBehaviour,  IDeath
{
    private int screen = 3;

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

    public void OnDeath()
    {
        if(canDie)
            GameManager.Instance.ResultScreen(screen);
    }
}
