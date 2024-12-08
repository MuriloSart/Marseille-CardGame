public class ResetDeckState : BattleStates
{
    private Deck discardDeck;
    private DrawPile deck;

    //Temporizadores
    private float startTime;
    private readonly float delay = .1f;
    private int cardIndex = 0;

    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);

        discardDeck = (Deck)objs[0];
        deck = (DrawPile)objs[1];

        startTime = UnityEngine.Time.time;
        cardIndex = discardDeck.cards.Count - 1;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        if (UnityEngine.Time.time > startTime + delay)
        {
            //GameStateManager.Instance.ResetDeck(discard, deck, cardIndex, delay*2);
            cardIndex--;
            startTime = UnityEngine.Time.time;
        }
    }
}
