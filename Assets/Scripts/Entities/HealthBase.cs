using System;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;
    public Entity player;
    private int _currentLife;

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

    public void Heal(int heal)
    {
        _currentLife += heal;
        if (_currentLife > startLife)
            _currentLife = startLife;
    }

    private void Lose()
    {
        player.Lose();
    }
}
