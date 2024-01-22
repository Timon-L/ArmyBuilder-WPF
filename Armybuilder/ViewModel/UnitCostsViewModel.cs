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
    public class UnitCostsViewModel : Observable
    {   
        public UnitCostsViewModel() 
        {
            UnitsCost_dic = new();
        }
        public Dictionary<long, UnitCost> UnitsCost_dic { get; }
        public void LoadUnitCosts(ArmybuilderContext _context, Dictionary<long, Unit> units)
        {
            _context.Database.EnsureCreated();
            var unitsCost = _context.UnitCosts.ToList();

            foreach (var unitCost in unitsCost)
            {
                if (unitCost.FkUnitCostId.HasValue && units.TryGetValue(unitCost.FkUnitCostId.Value, out var tmpUnit))
                {
                    if (!tmpUnit.UnitCosts.Contains(unitCost))
                    {
                        tmpUnit.UnitCosts.Add(unitCost);
                    }
                }

                UnitsCost_dic[unitCost.UnitCostId] = unitCost;
            }
        }
    }
}
