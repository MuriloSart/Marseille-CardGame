using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private GameObject card;
    public List<GameObject> cards;

    private void Awake()
    {
        int damage = 0;
        for (int i = 0; i < 40; i++)
        {
            var obj = Instantiate(card);
            obj.transform.SetParent(this.transform);
            obj.transform.position = this.transform.position;

            obj.GetComponent<CardBase>().CreateCard(i/10, 1 + damage);

            damage++;
            if (damage > 9)
            {
                damage = 0;
            }

            cards.Add(obj);
        }
    }
}
