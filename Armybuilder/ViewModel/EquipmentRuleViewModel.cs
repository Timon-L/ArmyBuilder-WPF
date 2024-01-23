using ArmyBuilder.Base;
using ArmyBuilder.Models;
using ZstdSharp.Unsafe;

namespace ArmyBuilder.ViewModel
{
    public class EquipmentRuleViewModel : Observable
    {
        public Dictionary<long, List<EquipmentRule>> EquipmentRuleByEqId_dic { get; } = new();

        public void LoadEquipmentRule(ArmybuilderContext _context,
            Dictionary<long, Rule> Rules_dic, Dictionary<long, Equipment> Equipment_dic)
        {
            EquipmentRuleByEqId_dic.Clear();
            var EquipmentRules = _context.EquipmentRules.ToList();

            foreach(var equipmentRule in EquipmentRules) 
            { 
                if(Rules_dic.TryGetValue(equipmentRule.RulesRuleId, out var tmpRule)) 
                {
                    equipmentRule.RulesRule = tmpRule;
                }
                if(Equipment_dic.TryGetValue(equipmentRule.EquipmentEquipmentId, out var tmpEquipment))
                {
                    equipmentRule.EquipmentEquipment = tmpEquipment;
                } 
                if(EquipmentRuleByEqId_dic.TryGetValue(equipmentRule.EquipmentEquipmentId, out var tmpList))
                {
                    tmpList.Add(equipmentRule);
                }
                else
                {
                    tmpList = new();
                    tmpList.Add(equipmentRule);
                    EquipmentRuleByEqId_dic[equipmentRule.EquipmentEquipmentId] = tmpList;
                }
            }
        }
    }
}
