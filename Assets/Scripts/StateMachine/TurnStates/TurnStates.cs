
public class TurnStates : StateBase
{
    
}

public class PlayerTurnState : TurnStates
{
    private Player entity;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        
        entity = (Player)objs[0];

        entity.state = Player.PlayerStates.ATTACK;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();

        if (entity.selected)
            GameManager.Instance.EnemyAttack();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        entity.state = Player.PlayerStates.DONTATTACK;
    }
}

public class EnemyTurnState : TurnStates
{
    private Player entity;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);

        entity = (Player)objs[0];

        entity.state = Player.PlayerStates.ATTACK;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();

        if (entity.selected && entity.state == Player.PlayerStates.ATTACK)
        {
            GameManager.Instance.EnemyAutoSelect();
            entity.state = Player.PlayerStates.DONTATTACK;
        }
    }
}
