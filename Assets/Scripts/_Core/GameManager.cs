using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]private GameObject card;
    [SerializeField]private GameObject pack;
    public Player player;
    public Player enemy;
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
            obj.GetComponent<CardBase>().currentElement = (CardBase.ElementType) index;
            obj.GetComponent<CardBase>().dmg = 1 + i - decimalCount;
            indexCount++;
            if (indexCount > 9)
            {
                decimalCount += 10;
                indexCount = 0;
            }

            cards.Add(obj);
        }
        StartGame();
        player.AcquiringCards();
        enemy.AcquiringCards();
    }

    public void StartGame()
    {
        DealingCards(player);
        DealingCards(enemy);
    }

    public void DealingCards(Player player)
    {
        int index = UnityEngine.Random.Range(0, cards.Count);
        player.cards.Add(cards[index]);
        cards.RemoveAt(index);
    }

    public static void BattleTime(Player player)
    {
        if (player != null && player.cards.Count > 0)
        {
            player.Damage(player.cards[0].GetComponent<CardBase>().dmg, player.cards[0].GetComponent<CardBase>().currentElement.ToString());
            player.cards.RemoveAt(0);
        }
    }
}
