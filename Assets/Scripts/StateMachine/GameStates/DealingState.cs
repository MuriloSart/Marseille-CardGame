public class DealingState : BattleStates
{
    private Entity player;
    private Entity enemy;
    private int _currentBattle = 0;
    private FSM_Battle battleState;

    //Temporizadores
    private float startTime;
    private float delay;

    public override void OnStateEnter(params object[] objs)
    {
        if(objs == null || objs.Length < 5) return;
        base.OnStateEnter(objs);
        player = (Entity)objs[0];
        enemy = (Entity)objs[1];
        battleState = (FSM_Battle)objs[3];
        delay = (int)objs[4];

        player.state = Entity.EntityStates.DONTATTACK;
        enemy.state = Entity.EntityStates.DONTATTACK;

        _currentBattle = Dealer.Instance.FillHands(player, enemy, _currentBattle);

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
}
