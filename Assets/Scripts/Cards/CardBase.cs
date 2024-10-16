using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardBase : MonoBehaviour
{
    [Header("Status Card")]
    public int dmg = 1;
    public TextMeshProUGUI uiTextValue;
    public Color color;

    //privates
    private Entity _currentOwner;
    private bool _acquired = false;
    private bool _acquiredOwner = false;

    public bool Acquired 
    { 
        get { return _acquired; } 
    }
    public abstract void UseAbility();

    public abstract Sprite Render();

    private void Start()
    {
        uiTextValue.text = dmg.ToString();
        this.GetComponent<Image>().sprite = Render();
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
        if(_currentOwner != null && _currentOwner.state == Entity.PlayerStates.ATTACK)
        {
            _currentOwner.OnClick(this);
            _acquired = false;
        }
    }
}
