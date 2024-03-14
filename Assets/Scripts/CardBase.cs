using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour
{
    public int dmg = 1;
    public ElementType currentElement;
    public Player currentOwner;

    private bool _acquired = false;

    public enum ElementType
    {
        Fire,
        Water,
        Earth,
        Air
    }

    public void Acquire(Player player)
    {
        player.OnClick(this);
    }

    public void OnClick()
    {
        if (!_acquired)
        {
            Acquire(currentOwner);
        }
        _acquired = true;
    }
}
