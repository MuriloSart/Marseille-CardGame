public class AttackingState : BattleStates
{
    private Entity player;
    private Entity enemy;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        player = (Entity)objs[0];
        enemy = (Entity)objs[1];
        player.entityTurn = true;


        foreach (var card in player.cardsOnHand.cards)
        {
            card.Ability = card.AttackAbility;
        }
        
        GameStateManager.Instance.PlayerAttack();
        GameStateManager.Instance.ValueStage();
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        player.selected = false;
        enemy.selected = false;
        player.entityTurn = false;

        foreach (var card in player.cardsOnHand.cards)
        {
            card.Ability = card.DefenseAbility;
        }
    }
}
