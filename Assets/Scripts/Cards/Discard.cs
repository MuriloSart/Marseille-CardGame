using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : MonoBehaviour
{
    public List<GameObject> discardPack;
    public void AcquiringCards(GameObject card)
    {
        discardPack.Add(card);
        card.transform.SetParent(this.transform);
        card.transform.position = this.transform.position;
    }
}
