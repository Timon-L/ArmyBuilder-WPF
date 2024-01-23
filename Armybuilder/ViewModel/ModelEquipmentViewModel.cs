using ArmyBuilder.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBuilder.Models
{
    public class ModelEquipmentViewModel : Observable
    {
        public Dictionary<long, List<ModelEquipment>> ModelEquipmentsByModelId_dic { get; } = new();

        public void LoadModelEquipments(ArmybuilderContext _context, 
            Dictionary<long, Equipment> Equipment_dic, Dictionary<long, Model> Model_dic)
        {
            ModelEquipmentsByModelId_dic.Clear();
            _context.Database.EnsureCreated();

            var modelEquipments = _context.ModelEquipments.ToList();

            foreach(var modelEquipment in  modelEquipments)
            {
                if(Equipment_dic.TryGetValue(modelEquipment.EquipmentsEquipmentId, out var tmpEquipment))
                {
                    modelEquipment.EquipmentsEquipment = tmpEquipment;
                }
                if(Model_dic.TryGetValue(modelEquipment.ModelModelId, out var tmpModel))
                {   
                    modelEquipment.ModelModel = tmpModel;
                }
                if(ModelEquipmentsByModelId_dic.TryGetValue(modelEquipment.ModelModelId, out var tmpList))
                {
                    tmpList.Add(modelEquipment);
                }
                else
                {
                    tmpList = new();
                    tmpList.Add(modelEquipment);
                    ModelEquipmentsByModelId_dic[modelEquipment.ModelModelId] = tmpList;
                }
            }
        }
    }
}
