using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CardBase;

public class GameManager : Singleton<GameManager>
{
    public GameObject card;
    public GameObject pack;
    public List<GameObject> cards;

    public override void Awake()
    {
        int decimalCount = 0;
        int indexCount = 0;
        for (int i = 0; i < 100; i++)
        {
            var obj = Instantiate(card);
            obj.transform.SetParent(pack.transform);
            obj.transform.position = pack.transform.position;

            int index = decimalCount / 10;
            if (index >= 5)
                index -= 5;
            obj.GetComponent<CardBase>().currentElement = (ElementType) index;
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
    public static void BattleTime(Player player)
    {
        if (player == null && player.cards.Count > 0)
        {
            player.Damage(player.cards[0].dmg, player.cards[0].currentElement.ToString());
            player.cards.RemoveAt(0);
        }
    }
}
