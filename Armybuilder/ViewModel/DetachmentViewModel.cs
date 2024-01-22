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
    public class DetachmentViewModel : Observable
    {   
        public DetachmentViewModel() 
        {
            Detachments = new();
        }
        public ObservableCollection<Detachment> Detachments { get; }

        public void LoadDetachments(ArmybuilderContext _context)
        {
            Detachments.Clear();
            _context.Database.EnsureCreated();
            var detachments = _context.Detachments.ToList();

            foreach (var detachment in detachments)
            {
                Detachments.Add(detachment);
            }
        }
    }
}
