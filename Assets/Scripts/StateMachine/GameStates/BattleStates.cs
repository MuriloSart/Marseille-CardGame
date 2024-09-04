public class BattleStates : StateBase
{

}

public class DealingState : BattleStates
{
    private Player player;
    private Player enemy;
    private Deck pack;
    private int _currentBattle;
    private FSM_Battle battleState;

    //Temporizadores
    private float startTime;
    private float delay = 1;

    public override void OnStateEnter(params object[] objs)
    {
        if(objs == null || objs.Length < 5) return;
        base.OnStateEnter(objs);
        player = (Player)objs[0];
        enemy = (Player)objs[1];
        pack = (Deck)objs[2];
        battleState = (FSM_Battle)objs[3];
        delay = (int)objs[4];
        

        player.state = Player.PlayerStates.DONTATTACK;
        _currentBattle = GameManager.Instance.DealingCards(player, enemy, pack);
        startTime = UnityEngine.Time.time;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();

        if (UnityEngine.Time.time > startTime + delay) 
        {
            if (_currentBattle == 1)
                battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.ATTACKING, player, enemy);
            else
                battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.DEFENSE, player, enemy);
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}

public class AttackingState : BattleStates
{
    private Player player;
    private Player enemy;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);

        GameManager.Instance.PlayerAttack();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        player.selected = false;
        enemy.selected = false;
    }
}

public class DefenseState : BattleStates
{
    private Player player;
    private Player enemy;

    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);

        GameManager.Instance.EnemyAttack();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        player.selected = false;
        enemy.selected = false;
    }
}

public class ResetDeckState : BattleStates
{
    private Discard discard;
    private Deck deck;
    private FSM_Battle battleState;

    //Temporizadores
    private float startTime;
    private float delay = .1f;
    private int cardIndex = 0;

    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);

        discard = (Discard)objs[0];
        deck = (Deck)objs[1];

        startTime = UnityEngine.Time.time;
        cardIndex = discard.discardPack.Count - 1;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        if (UnityEngine.Time.time > startTime + delay)
        {
            GameManager.Instance.ResetDeck(discard, deck, cardIndex, delay*2);
            cardIndex--;
            startTime = UnityEngine.Time.time;
        }
    }
}
