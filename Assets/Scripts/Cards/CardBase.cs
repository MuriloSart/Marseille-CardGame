using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBase : MonoBehaviour
{
    public int dmg = 1;
    public ElementType currentElement = ElementType.Paus;
    public Player currentOwner;

    //privates
    private bool _acquired = false;

    public enum ElementType
    {
        Paus,
        Copas,
        Espada,
        Ouro,
    }

    public void Acquire(Player player)
    {
        if (!_acquired)
            currentOwner = player;
        _acquired = true;
    }

    public void OnClick()
    {
        if(currentOwner != null)
            currentOwner.OnClick(this);
    }
}
