using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]private List<GameObject> cardTypes;
    public List<CardBase> cards;

    private void Awake()
    {
        int damage = 1;
        for (int i = 0; i < 40; i++)
        {
            cardTypes[i / 10].GetComponent<CardBase>().Damage = damage;
            var obj = Instantiate(cardTypes[i/10]);
            obj.transform.SetParent(this.transform);
            obj.transform.position = this.transform.position;

            damage++;
            if (damage > 10)
            {
                damage = 1;
            }

            cards.Add(obj.GetComponent<CardBase>());
        }
    }
}
