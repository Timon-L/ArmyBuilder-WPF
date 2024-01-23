using ArmyBuilder.Base;
using ArmyBuilder.Models;

namespace ArmyBuilder.ViewModel
{
    public class EquipmentViewModel : Observable
    {
        public Dictionary<long, Equipment> Equipment_dic { get; } = new();

        public void LoadEquipment(ArmybuilderContext _context)
        {
            Equipment_dic.Clear();
            var equipments = _context.Equipment.ToList();

            foreach(var equip in equipments) 
            {   
                if(!Equipment_dic.ContainsKey(equip.EquipmentId))
                {
                    Equipment_dic[equip.EquipmentId] = equip;
                }
            }
        }
    }
}
