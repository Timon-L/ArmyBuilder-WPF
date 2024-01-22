using ArmyBuilder.Base;
using ArmyBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBuilder.ViewModel
{
    public class UnitsViewModel : Observable
    {   
        public UnitsViewModel() 
        {
            Units_dic = new();
            UnitsByFaction_dic = new();
        }
        public Dictionary<long, Unit> Units_dic { get; }
        public Dictionary<Faction, List<Unit>> UnitsByFaction_dic { get; }
        public void LoadUnits(ArmybuilderContext _context, Dictionary<long, Faction> Factions_dic)
        {
            Units_dic.Clear();
            _context.Database.EnsureCreated();
            var units = _context.Units.ToList();

            foreach (var unit in units)
            {
                if(unit.FkFactionId.HasValue && Factions_dic.TryGetValue(unit.FkFactionId.Value, out var tmpFaction))
                {
                    unit.FkFaction = tmpFaction;
                    if (UnitsByFaction_dic.TryGetValue(tmpFaction, out List<Unit> tmpList))
                    {
                        tmpList.Add(unit);
                    }
                    else
                    {
                        tmpList = new List<Unit>();
                        tmpList.Add(unit);
                        UnitsByFaction_dic[tmpFaction] = tmpList;
                    }
                }
                Units_dic.Add(unit.UnitId, unit);

            }

        }
    }
}
