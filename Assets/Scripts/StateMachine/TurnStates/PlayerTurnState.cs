
public class PlayerTurnState : TurnStates
{
    private Entity player;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
       
        player = (Entity)objs[0];
        player.state = Entity.EntityStates.ATTACK;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        if (player.entityTurn && player.selected)
            GameStateManager.Instance.EnemyAttack();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        player.state = Entity.EntityStates.DONTATTACK;
    }
}
