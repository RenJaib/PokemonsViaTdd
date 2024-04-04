using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonsViaTdd
{
    public class Player
    {
        public bool AskedToEvolve { get; set; }


        public void SendNotification()
        {
            Console.WriteLine("Notification send to player to evolve");
            AskedToEvolve = true;
        }

    }
}
