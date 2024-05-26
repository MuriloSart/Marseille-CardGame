using System;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;
    [SerializeField]private int _currentLife;
    public Player player;

    private void Awake()
    {
        Init();
    }

    public int CurrentLife
    {
        get { return _currentLife; }
    }

    private void Init()
    {
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            _currentLife = 0;
            Lose();
        }
    }

    private void Lose()
    {
        player.Lose();
    }
}
