using UnityEngine;
using DG.Tweening;

namespace Cards.Animations
{
    public class CardAnimator : MonoBehaviour
    {
        public int delay = 1;
        public virtual void SlideTo(CardBase card, Deck destiny)
        {
            card.transform.DOMove(destiny.transform.position, delay);
        }
    }
}
