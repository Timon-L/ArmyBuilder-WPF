using ArmyBuilder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBuilder.ViewModel
{
    public class PointsCalculation
    {
        public int getTotalPoints(ObservableCollection<Detachment> SelectedDetachments)
        {
            int totalPoints = 0;

            foreach (var detachment in SelectedDetachments)
            {
                foreach (var detachmentUnit in detachment.DetachmentUnits)
                {
                    totalPoints += detachmentUnit.Quantity * detachmentUnit.UnitCost?.PointCost ?? 0;
                }
            }

            return totalPoints;
        }

        public int getDetachmentPoints(Detachment detachment)
        {
            int detachmentPoints = 0;

            foreach (var detachmentUnit in detachment.DetachmentUnits)
            {
                detachmentPoints += detachmentUnit.Quantity * detachmentUnit.UnitCost?.PointCost ?? 0;
            }

            return detachmentPoints;
        }
    }
}
