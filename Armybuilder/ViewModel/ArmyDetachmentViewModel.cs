using ArmyBuilder.Base;
using ArmyBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBuilder.ViewModel
{
    public class ArmyDetachmentViewModel : Observable
    {   
        public ArmyDetachmentViewModel() 
        {
            ArmyDetachment = new();
        }

        public ObservableCollection<ArmyDetachment> ArmyDetachment { get; }
        public void LoadArmyDetachment(ArmybuilderContext _context, 
            ObservableCollection<Army> armiesList, ObservableCollection<Detachment> detachmentsList)
        {
            ArmyDetachment.Clear();
            _context.Database.EnsureCreated();
            var attachments = _context.ArmyDetachments.ToList();

            foreach (var attachment in attachments)
            {
                ArmyDetachment.Add(attachment);
                foreach (var detachment in detachmentsList)
                {
                    if (detachment.DetachmentId == attachment.DetachmentsDetachmentId)
                    {
                        attachment.DetachmentsDetachment = detachment;
                        break;
                    }
                }

                foreach (var army in armiesList)
                {
                    if (army.Id == attachment.ArmyId)
                    {
                        attachment.Army = army;
                        break;
                    }
                }
            }
        }
    }
}
