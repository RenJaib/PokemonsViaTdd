namespace PokemonsViaTdd;

public class AttackType
{
    public AttackType(string type, int power)
    {
        Type = type;
        Power = power;
    }

    public string Type { get; set; }
    public double Power { get; set; }
}