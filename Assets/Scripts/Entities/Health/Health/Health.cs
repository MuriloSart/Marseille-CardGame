using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxLife = 10;
    public Entity player;
    private int _currentLife;

    public int Life { get => _currentLife;  }

    private void Awake()
    {
        Init();
    }

    public int CurrentLife
    {
        get => _currentLife;

        set 
        { 
            if ( value <= maxLife && value > 0)
                _currentLife = value;
            else if (value < 0)
                _currentLife = 0;
            else
                _currentLife = maxLife;
        }
    }

    private void Init()
    {
        _currentLife = maxLife;
    }
}
