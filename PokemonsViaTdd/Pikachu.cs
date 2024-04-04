namespace PokemonsViaTdd;

public class Pikachu
{
    public Pikachu()
    {
        Level = 1;
    }

    public int Level { get; private set; }

    public int ExperiencePoints { get; private set; }
    public bool IsEvolved { get; private set; } = false;

    public void GainExperience(int experiencePoints)
    {
        ExperiencePoints += experiencePoints;
    }

    public void LevelUp() // not a function
    {
        Level++; //mutable

        if (Level == 10)
        {
            IsEvolved = true;
        }
    }

    public int PureFunctionLevelUp(int level) // function
    {
        return level + 1; //immutable
    }

    public AttackType Attack()
    {
        return new AttackType("Thunderstrike", 10);
    }
}