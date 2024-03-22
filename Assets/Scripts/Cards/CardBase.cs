using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour
{
    public int dmg = 1;
    public ElementType currentElement = ElementType.Fire;
    public Player currentOwner;

    //privates
    private bool _acquired = false;

    public enum ElementType
    {
        Fire,
        Water,
        Earth,
        Air,
        Mana
    }

    public void Acquire(Player player)
    {
        if (!_acquired)
            currentOwner = player;
        _acquired = true;
    }

    public void OnClick()
    {
        //if(currentOwner != null)
            //GameManager.BattleTime(currentOwner);
    }
}
