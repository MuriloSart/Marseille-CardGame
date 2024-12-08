using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    [Header("Enemy")]
    public Entity enemy;

    [Header("Decks")]

    [Tooltip("Deck On Hand")]
    public Deck cardsOnHand;
    public GameObject layoutCards;

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

    [Header("Effects")]
    public int effectResist = 0;
    public int damageResist = 0;
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

    public enum EntityStates { ATTACK, DONTATTACK }

    public void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        effects = new List<EffectBase>();
    }

    public virtual void OnClick(CardBase cardClicked)
    {
        if (state == EntityStates.DONTATTACK || !cardClicked.Acquired) return;

        state = EntityStates.DONTATTACK;
        CardsManager.Instance.SelectingCard(this, cardClicked);
    }

    public void AcquiringCards()
    {
        int index = 1;
        foreach (var card in cardsOnHand.cards)
        {
            card.Acquire(this);
            StartCoroutine(CardsManager.Instance.SlideToHand(card, layoutCards.GetComponent<HorizontalLayoutGroup>(), index));
            index += 2;
        }
    }
}
