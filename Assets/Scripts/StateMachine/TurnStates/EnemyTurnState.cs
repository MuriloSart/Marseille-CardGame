

public class EnemyTurnState : TurnStates
{
    private Enemy enemy;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);

        enemy = (Enemy)objs[0];
        enemy.state = Enemy.EntityStates.ATTACK;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();

        if (enemy.state == Enemy.EntityStates.ATTACK)
        {
            enemy.AutoSelect();
            enemy.state = Enemy.EntityStates.DONTATTACK;
        }
    }
}
