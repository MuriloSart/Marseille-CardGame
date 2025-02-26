using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Entities.LifeCycle.Death;

public class Entity : MonoBehaviour
{
    [Header("Enemy")]
    public Entity enemy;

    [Header("Decks")]

    [Tooltip("Deck On Hand")]
    public Deck cardsOnHand;
    [SerializeField] private Transform grid;

    [Tooltip("SelectedCards")]
    public Deck selectedCards;
    [SerializeField] private GameObject SelectedPos;
    [SerializeField] private GameObject SelectedPos2;

    [Tooltip("Discard Deck")]
    public Deck discardDeck;

    [Tooltip("Draw Pile")]
    public DrawPile drawPile;
    
    [Header("Player Stats")]
    public HealthUi healthUi;
    public Health health;
    public Death death;

    public List<EffectBase> effects;

    [HideInInspector] public EntityStates state = EntityStates.DONTATTACK;
    [HideInInspector] public bool entityTurn = false;
    [HideInInspector] public bool selected = false;

    private Vector2 _currentSelectPos;
    public Vector2 CurrentSelectedPos { get => _currentSelectPos; }
    public int SelectedPosOption
    {
        set 
        {
            if (value == 1)
                _currentSelectPos = SelectedPos.transform.position;
            else if(value == 2)
                _currentSelectPos = SelectedPos2.transform.position;
        }
    }

    private int _effectResist = 0;
    public int EffectResist
    {
        get => _effectResist;
        set
        {
            if (value > 0)
                _effectResist = value;
            else
                _effectResist = 0;
        }
    }

    private int _damageResist = 0;
    public int DamageResist
    {
        get { return _damageResist; }
        set 
        {
            if (value > 0)
                _damageResist = value;
            else
                _damageResist = 0;
        }
    }

    public enum EntityStates { ATTACK, DONTATTACK }

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        effects = new List<EffectBase>();
    }

    private void Update()
    {
        Death();
    }

    private void Death()
    {
        if (health.Life <= 0 && death.canDie) death.OnDeath();
        else if (health.Life <= 0 && !death.canDie) health.CurrentLife = 1;
    }

    public virtual void OnClick(CardBase cardClicked)
    {
        if (state == EntityStates.DONTATTACK || !cardClicked.Acquired) return;

        state = EntityStates.DONTATTACK;
        CardsManager.Instance.SelectingCard(this, cardClicked);
    }

    public void AcquireCards()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(grid.GetComponent<RectTransform>());
        for (int i = 0; i < cardsOnHand.cards.Count; i++)
        {

            if (grid != null)
            {
                cardsOnHand.cards[i].Acquire(this);
                ToHand(cardsOnHand.cards[i], i);
            }
            else
            {
                Debug.LogWarning( name + " não tem um layout não definito");
            }

        }
    }

    private void ToHand(CardBase card, int i)
    {
        var child = grid.GetChild(i);
        card.transform.DOMove(child.position, 1);
    }
}
