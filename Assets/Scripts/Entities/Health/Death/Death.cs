using UnityEngine;
public class Death : MonoBehaviour,  IDeath
{
    private int screen = 3;

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
        GameManager.Instance.ResultScreen(screen);
    }
}
