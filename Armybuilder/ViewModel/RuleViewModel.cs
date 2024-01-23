using ArmyBuilder.Base;
using ArmyBuilder.Models;

namespace ArmyBuilder.ViewModel
{
    public class RuleViewModel : Observable
    {
        public Dictionary<long, Rule> Rules_dic { get; } = new();
        public void LoadRules(ArmybuilderContext _context)
        {
            Rules_dic.Clear();
            var rules = _context.Rules.ToList();

            foreach(var rule in rules)
            {   
                if(!Rules_dic.ContainsKey(rule.RuleId))
                {
                    Rules_dic[rule.RuleId] = rule;
                }
            }
        }
    }
}
