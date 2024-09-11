using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Entity;

public class CardBase : MonoBehaviour
{
    [Header("Status Card")]
    public int dmg = 1;
    public ElementType currentElement = ElementType.Esperanca;
    public TextMeshProUGUI uiTextValue;
    public Color color;

    //privates
    [SerializeField] private Entity _currentOwner;
    private bool _acquired = false;
    private bool _acquiredOwner = false;

    public bool Acquired 
    { 
        get { return _acquired; } 
    }

    private void Start()
    {
        uiTextValue.text = dmg.ToString();
    }

    public void CreateCard(int i, int dmg)
    {
        switch (i) 
        {
            case 0:
                this.currentElement = ElementType.Esperanca;
                this.gameObject.GetComponent<Image>().color = Color.green;
                break;
            case 1:
                this.currentElement = ElementType.Amor;
                this.gameObject.GetComponent<Image>().color = Color.red;
                break;
            case 2:
                this.currentElement = ElementType.Culpa;
                this.gameObject.GetComponent<Image>().color = Color.cyan;
                break;
            case 3:
                this.currentElement = ElementType.Luto;
                this.gameObject.GetComponent<Image>().color = Color.yellow;
                break;
        }

        this.dmg = dmg;
    }

    public enum ElementType
    {
        Esperanca,
        Luto,
        Culpa,
        Amor
    }

    public void Acquire(Entity player)
    {
        if (_acquiredOwner) return;

        if (!_acquired)
            _currentOwner = player;
        _acquired = true;
        _acquiredOwner = true;
    }

    public void OnClick()
    {
        if(_currentOwner != null && _currentOwner.state == PlayerStates.ATTACK)
        {
            _currentOwner.OnClick(this);
            _acquired = false;
        }
    }
}
