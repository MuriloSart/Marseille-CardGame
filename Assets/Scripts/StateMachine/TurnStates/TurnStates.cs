
public class TurnStates : StateBase
{
    
}

public class PlayerTurnState : TurnStates
{
    private Entity player;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
       
        player = (Entity)objs[0];
        player.state = Entity.PlayerStates.ATTACK;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        if (player.entityTurn && player.selected)
            GameManager.Instance.EnemyAttack();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        player.state = Entity.PlayerStates.DONTATTACK;
    }
}

public class EnemyTurnState : TurnStates
{
    private Entity enemy;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);

        enemy = (Entity)objs[0];

        enemy.state = Entity.PlayerStates.ATTACK;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();

        if (enemy.state == Entity.PlayerStates.ATTACK)
        {
            GameManager.Instance.EnemyAutoSelect();
            enemy.state = Entity.PlayerStates.DONTATTACK;
        }
    }
}
