using UnityEngine;

public class HopeCard : CardBase
{
    private readonly IAbilityCard _ability;

    public HopeCard()
    {
        _ability = new HopeAbility();
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
