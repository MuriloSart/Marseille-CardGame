using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPack : MonoBehaviour
{
    [SerializeField] private GameObject card;
    public List<GameObject> cards;
    private void Awake()
    {
        int decimalCount = 0;
        int indexCount = 0;
        for (int i = 0; i < 100; i++)
        {
            var obj = Instantiate(card);
            obj.transform.SetParent(this.transform);
            obj.transform.position = this.transform.position;

            int index = decimalCount / 10;
            if (index >= 5)
                index -= 5;
            obj.GetComponent<CardBase>().currentElement = (CardBase.ElementType)index;
            obj.GetComponent<CardBase>().dmg = 1 + i - decimalCount;
            indexCount++;
            if (indexCount > 9)
            {
                decimalCount += 10;
                indexCount = 0;
            }

            cards.Add(obj);
        }
    }
}
