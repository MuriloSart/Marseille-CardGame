using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardBase : MonoBehaviour
{
    [Header("Status Card")]
    public int dmg = 1;
    public ElementType currentElement = ElementType.Paus;
    public TextMeshProUGUI uiTextValue;

    //privates
    private Player currentOwner;
    private bool _acquired = false;

    private void Start()
    {
        uiTextValue.text = dmg.ToString();
    }

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
