using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    [SerializeField] private GameObject card;
    public List<GameObject> cards;

    //Privates
    private Color _paintColor = Color.green; 

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
