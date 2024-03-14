using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<CardBase> cards;
    public Player enemy;
    public HealthBase health;

    public void Damage(int damage, string type)
    {
        if (enemy.cards.Count > 0)
        {
            if (enemy.cards != null && enemy.cards[0].currentElement.ToString() == type)
                damage -= enemy.cards[0].dmg;
        }
        enemy.health.Damage(damage);

    }
    public void OnClick(CardBase item)
    {
        cards.Add(item);
    }
}
