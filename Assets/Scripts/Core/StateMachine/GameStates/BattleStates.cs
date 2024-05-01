using System;
using Core.CountingTime;

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
    private DateTime startTime;
    private int delay = 3;
    private int time = 0;

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
        _currentBattle = GameManager.DealingCards(player, enemy, pack);
        startTime = DateTime.Now;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        time = CountingTime.CoolDown(startTime, delay);

        if (time >= delay) 
        {
            if (_currentBattle == 1)
            {
                battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.ATTACKING, player, enemy);
            }
            else
                battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.DEFENSE, player, enemy);
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        time = 0;
    }
}

public class AttackingState : BattleStates
{
    private Player player;
    private Player enemy;
    private bool EnemyAttacked = false;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        if (objs == null || objs.Length < 2)
        {
            return;
        }
        player = (Player)objs[0];
        enemy = (Player)objs[1];
        enemy.state = Player.PlayerStates.DONTATTACK;
        player.state = Player.PlayerStates.ATTACK;
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        var card = enemy.cards[UnityEngine.Random.Range(0, enemy.cards.Count)].GetComponent<CardBase>();
        if (player.selectedCard && !EnemyAttacked)
        {
            enemy.state = Player.PlayerStates.ATTACK;
            enemy.OnClick(card);
            EnemyAttacked = true;
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        EnemyAttacked = false;
        player.state = Player.PlayerStates.DONTATTACK;
    }
}

public class DefenseState : BattleStates
{
    private Player player;
    private Player enemy;
    private bool _checked = false;

    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        if (objs == null || objs.Length < 2)
        {
            return;
        }
        player = (Player)objs[0];
        enemy = (Player)objs[1];
        enemy.state = Player.PlayerStates.ATTACK;
        player.state = Player.PlayerStates.DONTATTACK;

        var card = enemy.cards[UnityEngine.Random.Range(0, enemy.cards.Count)].GetComponent<CardBase>();
        enemy.OnClick(card);
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
        if (enemy.selectedCard && !_checked)
        {
            player.state = Player.PlayerStates.ATTACK;
            _checked = true;
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        player.state = Player.PlayerStates.DONTATTACK;
        _checked = false;
    }
}
