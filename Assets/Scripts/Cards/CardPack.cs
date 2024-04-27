using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPack : MonoBehaviour
{
    [SerializeField] private GameObject card;
    public List<GameObject> cards;

    //Privates
    private Color _paintColor = Color.green; 

    private void Awake()
    {
        int decimalCount = 0;
        int indexCount = 0;
        for (int i = 0; i < 40; i++)
        {
            var obj = Instantiate(card);
            obj.transform.SetParent(this.transform);
            obj.transform.position = this.transform.position;
            obj.GetComponent<Image>().color = _paintColor;

            if(i > 10 && i <= 20)
                _paintColor = Color.red;
            else if(i > 20 && i <= 30)
                _paintColor = Color.black;
            else if(i > 30 && i <= 40)
                _paintColor = Color.yellow;

            int index = decimalCount / 10;
            if (index >= 4)
                index -= 4;
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
