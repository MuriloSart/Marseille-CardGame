using DG.Tweening;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Entities Reference")]
    public Entity player;
    public Entity enemy;
    public int maxCardNumber = 7;

    [Header("State Change Delay")]
    public int dealingDelay = 1;
    public int resetDeckDelay = 1;

    [Header("Packs")]
    public Deck deck;
    public Discard discard;

    [Header("Finite State Machines")]
    public FSM_Battle battleState;
    public FSM_Stage stageStage;
    public FSM_Turn turnState;

    //privates
    private static bool _resetDeck = false;
    private int _currentBattle = 0;

    private void Start()
    {
        OnDealing();
    }

    private void Update()
    {
        CheckingSelecteds();
        CheckingResetState();
    }

    public void CheckingSelecteds()
    {
        if(player.selected && enemy.selected)
        {

            if (battleState.stateMachine.CurrentState is DefenseState)
            {
                if (stageStage.stateMachine.CurrentState is ValueStage)
                {
                    EnemyAttack();
                    EffectStage();
                }
                else if (stageStage.stateMachine.CurrentState is EffectStage)
                {
                    enemy.DamageTurn();
                    OnDealing();
                }
            }
            else if (battleState.stateMachine.CurrentState is AttackingState)
            {
                if (stageStage.stateMachine.CurrentState is ValueStage)
                {
                    PlayerAttack();
                    EffectStage();
                }
                else if (stageStage.stateMachine.CurrentState is EffectStage)
                {
                    player.DamageTurn();
                    OnDealing();
                }
            }
        }
        else if(!player.selected && enemy.selected)
            PlayerAttack();
    }

    public void ValueStage()
    {
        stageStage.stateMachine.SwitchState(FSM_Stage.BattleStates.CARD_VALUE, player, enemy);
    }

    public void EffectStage()
    {
        stageStage.stateMachine.SwitchState(FSM_Stage.BattleStates.CARD_EFFECT, player, enemy);
    }

    public void PlayerAttack()
    {
        turnState.stateMachine.SwitchState(FSM_Turn.BattleStates.PLAYER_TURN, player);
    }

    public void EnemyAttack()
    {
        turnState.stateMachine.SwitchState(FSM_Turn.BattleStates.ENEMY_TURN, enemy);
    }

    public void EnemyAutoSelect()
    {
        var card = enemy.cards[Random.Range(0, enemy.cards.Count)].GetComponent<CardBase>();
        card.OnClick();
    }

    #region Dealing Cards

    public void OnDealing()
    {
        battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.DEALING, player, enemy, deck, battleState, dealingDelay);
    }

    public int DealingCards(Entity player, Entity enemy, Deck pack)
    {
        DealToPlayer(player, pack);
        DealToPlayer(enemy, pack);

        if(_currentBattle == 0)
            _currentBattle = 1;
        else if(_currentBattle == 1)
            _currentBattle = 0;

        return _currentBattle;
    }

    public void DealToPlayer(Entity player, Deck pack)
    {
        int amountDealing = maxCardNumber - player.cards.Count;
        for (int i = 0; i < amountDealing; i++)
        {
            int index = Random.Range(0, pack.cards.Count);
            player.cards.Add(pack.cards[index]);
            pack.cards.RemoveAt(index);
        }
        player.AcquiringCards();
    }

    #endregion

    #region ResetDeck

    private void CheckingResetState()
    {
        if (deck.cards.Count <= 0 || deck.cards == null)
            if (battleState.stateMachine.CurrentState is ResetDeckState)
                StartCoroutine(DelayToReset());

        if (_resetDeck)
        {
            OnDealing();
            _resetDeck = false;
        }
    }

    public void ResetDeck(Discard discard, Deck deck,int indexArray, float delay)
    {
        if (indexArray < 0)
        {
            _resetDeck = true;
            return;
        }
        Debug.Log(indexArray);
        CardBase card = discard.discardPack[indexArray];

        card.transform.DOMove(deck.transform.position, delay);
        deck.cards.Add(card);
        discard.discardPack.Remove(card);

    }

    private IEnumerator DelayToReset()
    {
        yield return new WaitForSeconds(resetDeckDelay);
        battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.RESETDECK, discard, deck);
    }

    #endregion
}
