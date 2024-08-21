using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardBase : MonoBehaviour
{
    [Header("Status Card")]
    public int dmg = 1;
    public ElementType currentElement = ElementType.Paus;
    public ElementType currentStrengthness = ElementType.Paus;
    public ElementType currentWeakness = ElementType.Paus;
    public TextMeshProUGUI uiTextValue;
    public Color color;

    //privates
    private Player _currentOwner;
    private bool _acquired = false;

    private void Start()
    {
        uiTextValue.text = dmg.ToString();
    }

    public void CreateCard(int i, int dmg)
    {
        switch (i) 
        {
            case 0:
                this.currentElement = ElementType.Paus;
                this.currentStrengthness = ElementType.Copas;
                this.currentWeakness = ElementType.Ouro;
                this.gameObject.GetComponent<Image>().color = Color.green;
                break;
            case 1:
                this.currentElement = ElementType.Copas;
                this.currentStrengthness = ElementType.Espada;
                this.currentWeakness = ElementType.Paus;
                this.gameObject.GetComponent<Image>().color = Color.red;
                break;
            case 2:
                this.currentElement = ElementType.Espada;
                this.currentStrengthness = ElementType.Ouro;
                this.currentWeakness = ElementType.Copas;
                this.gameObject.GetComponent<Image>().color = Color.cyan;
                break;
            case 3:
                this.currentElement = ElementType.Ouro;
                this.currentStrengthness = ElementType.Paus;
                this.currentWeakness = ElementType.Espada;
                this.gameObject.GetComponent<Image>().color = Color.yellow;
                break;
        }

        this.dmg = dmg;
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
            _currentOwner = player;
        _acquired = true;
    }

    public void OnClick()
    {
        if(_currentOwner != null)
            _currentOwner.OnClick(this);
    }
}
