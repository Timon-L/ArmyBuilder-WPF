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
    public class DetachmentUnitViewModel : Observable
    {   
        public DetachmentUnitViewModel() 
        {
            DetachmentUnits = new();
        }
        public ObservableCollection<DetachmentUnit> DetachmentUnits { get; }
        public void LoadDetachmentUnits(ArmybuilderContext _context, 
            ObservableCollection<Detachment> detachmentList, Dictionary<long, Unit> units, Dictionary<long, UnitCost> UnitsCost_dic)
        {
            DetachmentUnits.Clear();
            _context.Database.EnsureCreated();
            var detachmentUnits = _context.DetachmentUnits.ToList();

            foreach (var detachmentUnit in detachmentUnits)
            {
                DetachmentUnits.Add(detachmentUnit);
                if (detachmentUnit.UnitId.HasValue && units.TryGetValue(detachmentUnit.UnitId.Value, out var tmpUnit))
                {
                    detachmentUnit.Unit = tmpUnit;
                }
                if (detachmentUnit.UnitCostId.HasValue && UnitsCost_dic.TryGetValue(detachmentUnit.UnitCostId.Value, out var tmpUnitCost))
                {
                    detachmentUnit.UnitCost = tmpUnitCost;
                }
                foreach (var detachment in detachmentList)
                {
                    if (detachment.DetachmentId == detachmentUnit.DetachmentId)
                    {
                        detachmentUnit.Detachment = detachment;
                    }
                }
            }
        }
    }
}
