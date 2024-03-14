using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player player;
    public void BattleTime()
    {
        if (player == null && player.cards.Count > 0)
        {
            player.Damage(player.cards[0].dmg, player.cards[0].currentElement.ToString());
            player.cards.RemoveAt(0);
        }
    }
}
