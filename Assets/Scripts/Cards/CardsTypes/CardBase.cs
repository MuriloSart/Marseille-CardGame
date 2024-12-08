using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cards.Animations;

public abstract class CardBase : MonoBehaviour
{
    [Header("Status Card")]
    public TextMeshProUGUI uiTextValue;
    public Damage damageType;
    public CardAnimator cardAnimator;

 
    private bool _acquiredOwner = false;

    private int dmg = 1;
    public int Damage
    {
        set
        {
            if (value < 1)
                dmg = 1;
            else 
                dmg = value;

            uiTextValue.text = dmg.ToString();
        }
        get { return dmg; }
    }


    private bool _acquired = false;
    public bool Acquired 
    { 
        get { return _acquired; }
    }

    private Entity _currentOwner;
    public Entity Owner
    {
        get { return _currentOwner; }
    }


    protected IAbilityCard _ability;
    public IAbilityCard CurrentAbility
    {
        get { return _ability; }
    }

    protected EffectBase _effect;

    public EffectBase Effect
    {
        get { return _effect; }
    }

    #region Ability

    public Action Ability;

    public abstract void AttackAbility();

    public abstract void DefenseAbility();

    public abstract Sprite Render();

    #endregion

    private void Start()
    {
        uiTextValue.text = Damage.ToString();
        this.GetComponent<Image>().sprite = Render();
        Ability = DefenseAbility;
    }

    public void Acquire(Entity entity)
    {
        if (_acquiredOwner) return;

        if (!_acquired)
            _currentOwner = entity;
        _acquired = true;
        _acquiredOwner = true;
    }

    public void OnClick()
    {
        if (_currentOwner != null && _currentOwner.state == Entity.EntityStates.ATTACK)
        {
            _currentOwner.OnClick(this);
            _acquired = false;
        }
    }

    public void SlideTo(Deck destiny)
    {
        cardAnimator.SlideTo(this, destiny);
    }
}
