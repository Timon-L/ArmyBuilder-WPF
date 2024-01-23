using ArmyBuilder.Base;
using ArmyBuilder.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBuilder.ViewModel
{
    public class UnitRuleViewModel : Observable
    {
        public Dictionary<long, List<UnitRule>> UnitRulesByUnitId_dic { get; } = new();
        public void LoadUnitRules(ArmybuilderContext _context, 
            Dictionary<long, Unit>  Units_dic, Dictionary<long, Rule> Rules_dic)
        {
            var unitRules = _context.UnitRules.ToList();

            foreach (var unitRule in unitRules)
            {
                if(Units_dic.TryGetValue(unitRule.UnitUnitId, out var tmpUnit))
                {
                    unitRule.UnitUnit = tmpUnit;
                }
                if(Rules_dic.TryGetValue(unitRule.RulesRuleId, out var tmpRules))
                {
                    unitRule.RulesRule = tmpRules;
                }
                if(UnitRulesByUnitId_dic.TryGetValue(unitRule.UnitUnitId, out var tmpList))
                {
                    tmpList.Add(unitRule);
                }
                else
                {
                    tmpList = new();
                    tmpList.Add(unitRule);
                    UnitRulesByUnitId_dic[unitRule.UnitUnitId] = tmpList;
                }
            }
        }

        public List<Rule> FilterRuleByUnit(Unit unit)
        {   
            if(unit != null && UnitRulesByUnitId_dic.TryGetValue(unit.UnitId, out var tmpList))
            {
                return tmpList.Select(u => u.RulesRule).ToList();
            }

            return new List<Rule>();
        }
    }
}
