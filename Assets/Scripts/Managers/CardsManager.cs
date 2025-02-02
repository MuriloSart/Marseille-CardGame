using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : Singleton<CardsManager>
{
    public int animationDuration = 1;
    public TurnResult turnResult;
    public Entity player;
    public Entity enemy;


    public void DiscardSelected()
    {
        DiscardSelected(player);
        DiscardSelected(enemy);
    }

    private void DiscardSelected(Entity entity)
    {
        for (int i = entity.selectedCards.cards.Count - 1; i >= 0; i--)
        {
            var card = entity.selectedCards.cards[i];
            entity.selectedCards.DiscardTo(entity.discardDeck, card);
        }

        entity.selectedCards.cards.Clear();
    }

    public void SelectingCard(Entity entity, CardBase card)
    {
        entity.selectedCards.cards.Add(card);
        card.gameObject.transform.DOMove(entity.CurrentSelectedPos, animationDuration);
        entity.cardsOnHand.cards.Remove(card);

        StartCoroutine(DelayToSelect(entity, card));
    }
    private IEnumerator DelayToSelect(Entity entity, CardBase card)
    {
        yield return new WaitForSeconds(animationDuration);

        entity.selected = true;

        if (GameStateManager.Instance.stageStage.stateMachine.CurrentState is EffectStage)
        {
            card.Ability();
        }
        else if (GameStateManager.Instance.stageStage.stateMachine.CurrentState is ValueStage)
        {
            foreach (var effect in card.Owner.effects)
            {
                EffectManager.Instance.TakeEffectOverTurn(effect);
            }
        }
    }
}
