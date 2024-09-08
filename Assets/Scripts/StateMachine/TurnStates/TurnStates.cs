
public class TurnStates : StateBase
{
    
}

public class PlayerTurnState : TurnStates
{
    private Entity entity;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
       
        entity = (Entity)objs[0];

        entity.state = Entity.PlayerStates.ATTACK;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        if (entity.entityTurn && entity.selected)
            GameManager.Instance.EnemyAttack();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        entity.state = Entity.PlayerStates.DONTATTACK;
    }
}

public class EnemyTurnState : TurnStates
{
    private Entity entity;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);

        entity = (Entity)objs[0];

        entity.state = Entity.PlayerStates.ATTACK;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();

        if (entity.state == Entity.PlayerStates.ATTACK)
        {
            GameManager.Instance.EnemyAutoSelect();
            entity.state = Entity.PlayerStates.DONTATTACK;
        }
    }
}
