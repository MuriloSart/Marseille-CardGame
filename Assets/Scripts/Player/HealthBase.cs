using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;

    public int startLife = 10;

    public bool destroyOnKill = true;
    public float delayToKill = 0f;

    [SerializeField]private int _currentLife;

    public bool isDead = false;

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
        isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (isDead) return;
        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        isDead = true;
        if(destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
        OnKill?.Invoke();
    }
}
