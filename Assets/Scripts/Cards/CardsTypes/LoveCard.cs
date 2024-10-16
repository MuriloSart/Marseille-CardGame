using UnityEngine;

public class LoveCard : CardBase
{

    private IAbilityCard _ability;

    public LoveCard()
    {
        _ability = new LoveAbility();
    }

    public override Sprite Render()
    {
        return _ability.Render();
    }

    public override void UseAbility()
    {
        _ability.ExecuteAbility();
    }
}
