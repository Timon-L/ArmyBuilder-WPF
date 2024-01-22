using ArmyBuilder.Base;
using ArmyBuilder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBuilder.ViewModel
{
    public class FactionsViewModel : Observable
    {   
        public FactionsViewModel() 
        {
            Factions_dic = new();
        }
        public Dictionary<long, Faction> Factions_dic { get; }

        public void LoadFactions(ArmybuilderContext _context)
        {
            var allFactions = _context.Factions.ToDictionary(faction => faction.FactionId);
            foreach (var faction in allFactions)
            {
                Factions_dic.Add(faction.Key, faction.Value);
            }
        }
    }
}
