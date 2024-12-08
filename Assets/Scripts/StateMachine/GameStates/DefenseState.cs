public class DefenseState : BattleStates
{
    private Entity player;
    private Entity enemy;

    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        player = (Entity)objs[0];
        enemy = (Entity)objs[1];


        foreach (var card in enemy.cardsOnHand.cards)
        {
            card.Ability = card.AttackAbility;
        }

        GameStateManager.Instance.EnemyAttack();
        GameStateManager.Instance.ValueStage();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        player.selected = false;
        enemy.selected = false;

        foreach (var card in enemy.cardsOnHand.cards)
        {
            card.Ability = card.DefenseAbility;
        }
    }
}
