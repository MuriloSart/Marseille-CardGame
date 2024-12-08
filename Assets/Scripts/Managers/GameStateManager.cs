using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    [Header("Entities Reference")]
    public Entity player;
    public Enemy enemy;

    [Header("Packs")]
    public DrawPile deck;

    [Header("Finite State Machines")]
    public FSM_Battle battleState;
    public FSM_Stage stageStage;
    public FSM_Turn turnState;

    [Header("Resultados da Rodada")]
    public TurnResult turnResult;

    //privates
    private bool _clicked = false;

    private void Start()
    {
        OnDealing();
    }

    private void Update()
    {
        CheckingSelecteds();
    }

    public void CheckingSelecteds()
    {
        if(player.selected && enemy.selected)
        {
            _clicked = false;
            if (battleState.stateMachine.CurrentState is DefenseState)
            {
                if (stageStage.stateMachine.CurrentState is ValueStage)
                {
                    EnemyAttack();
                    EffectStage();
                }
                else if (stageStage.stateMachine.CurrentState is EffectStage)
                {
                    ResultStage(turnResult, enemy, enemy.selectedCards.cards[0].Damage - player.selectedCards.cards[0].Damage);
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
                    ResultStage(turnResult, player, player.selectedCards.cards[0].Damage - enemy.selectedCards.cards[0].Damage);
                    OnDealing();
                }
            }
        }
        else if (!player.selected && enemy.selected)
        {
            if(!_clicked)
            {
                _clicked = true;
                PlayerAttack();
            }
        }
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

    public void OnDealing()
    {
        battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.DEALING, player, enemy, deck, battleState, 1);
    }

    public void ResultStage(TurnResult turnResult, Entity entity, int damage)
    {
        battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.RESULT, entity, damage, turnResult);
    }

    #region ResetDeck

    //============== Criar e Usar Script para Gerenciar Reset de Discard Decks e Draw Piles =============

    //private void CheckingResetState()
    //{
    //    if (deck.cards.Count <= 0 || deck.cards == null)
    //        if (battleState.stateMachine.CurrentState is ResetDeckState)
    //            StartCoroutine(DelayToReset());

    //    if (_resetDeck)
    //    {
    //        OnDealing();
    //        _resetDeck = false;
    //    }
    //}

    //public void ResetDeck(Discard discard, DrawPile deck,int indexArray, float delay)
    //{
    //    if (indexArray < 0)
    //    {
    //        _resetDeck = true;
    //        return;
    //    }
    //    Debug.Log(indexArray);
    //    CardBase card = discard.discardPack[indexArray];

    //    card.transform.DOMove(deck.transform.position, delay);
    //    deck.cards.Add(card);
    //    discard.discardPack.Remove(card);

    //}

    //private IEnumerator DelayToReset()
    //{
    //    yield return new WaitForSeconds(resetDeckDelay);
    //    battleState.stateMachine.SwitchState(FSM_Battle.BattleStates.RESETDECK, discard, deck);
    //}

    #endregion
}
