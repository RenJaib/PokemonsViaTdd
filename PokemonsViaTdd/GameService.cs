namespace PokemonsViaTdd;

public class GameService
{
    
    public event EventHandler LevelUpEvent;

    public void BattleWonBy(Pikachu pokemon, Player player)
    {
        pokemon.GainExperience(1000);

        if (pokemon.ExperiencePoints >= 1000)
        {
            SendNotificationToPlayerToEvolve(player);
            OnLevelUpEvent();
        }
    }

    private void SendNotificationToPlayerToEvolve(Player player)
    {
        player.SendNotification();
    }

    public virtual void OnLevelUpEvent()
    {
        LevelUpEvent?.Invoke(this, EventArgs.Empty);
    }
}

//App Hierarchy structure