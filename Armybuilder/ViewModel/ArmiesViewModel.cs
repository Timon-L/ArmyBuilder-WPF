using ArmyBuilder.Base;
using ArmyBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBuilder.ViewModel
{
    public class ArmiesViewModel : Observable
    {

        public ArmiesViewModel() 
        {
            Armies = new();
        }
        public ObservableCollection<Army> Armies { get; }

        public void LoadArmies(ArmybuilderContext _context, Dictionary<long, Faction> Factions_dic)
        {
            Armies.Clear();

            _context.Database.EnsureCreated();
            var armies = _context.Armies.ToList();
            foreach (var army in armies)
            {
                if (army.FkFactionId.HasValue && Factions_dic.TryGetValue(army.FkFactionId.Value, out var Faction))
                {
                    army.FkFaction = Faction;
                }
                Armies.Add(army);
            }
        }
    }
}
