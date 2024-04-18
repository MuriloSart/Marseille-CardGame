using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //Players
    public Player player;
    public Player enemy;

    //Packs
    public CardPack pack;
    public Discard Discard;

    public override void Awake()
    {
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
        for(int i = 0; i < 5 ; i++)
        {
            int index = UnityEngine.Random.Range(0, pack.cards.Count);
            player.cards.Add(pack.cards[index]);
            pack.cards.RemoveAt(index);
        }
    }
}
