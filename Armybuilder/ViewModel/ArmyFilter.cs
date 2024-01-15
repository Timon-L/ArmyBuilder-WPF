using ArmyBuilder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBuilder.ViewModel
{
    public class ArmyFilter
    {
        private ObservableCollection<Detachment> detachments;
        private ObservableCollection<DetachmentUnit> detachmentUnits;
        private ObservableCollection<ArmyDetachment> armyDetachments;
        private List<Unit> units;

        public ArmyFilter(ObservableCollection<Detachment> detachments, 
            ObservableCollection<DetachmentUnit> detachmentUnits, ObservableCollection<ArmyDetachment> armyDetachments, List<Unit> units) 
        {
            this.detachments = detachments;
            this.detachmentUnits = detachmentUnits;
            this.armyDetachments = armyDetachments;
            this.units = units;
        }

        public ObservableCollection<Unit> SelectedUnits { get; } = new();

        public ObservableCollection<Detachment> SelectedDetachments { get; } = new();

        public ObservableCollection<DetachmentUnit> SelectedDetachmentUnits { get; } = new();

        public void FilterSelectedDetachments(Army selectedArmy)
        {
            SelectedDetachments.Clear();

            foreach(var armyDetachment in armyDetachments)
            {
                if(armyDetachment.Army == selectedArmy)
                {
                    SelectedDetachments.Add(armyDetachment.DetachmentsDetachment);
                }
            }
        }

        public void FilterSelectedDetachmentUnits(Detachment selectedDetachment)
        {
            SelectedDetachmentUnits.Clear();

            foreach(var detachmentUnit in detachmentUnits)
            {
                if(detachmentUnit.Detachment ==  selectedDetachment)
                {
                    SelectedDetachmentUnits.Add(detachmentUnit);
                }
            }
        }
    }
}
