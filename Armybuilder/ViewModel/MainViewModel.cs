using ArmyBuilder.Base;
using ArmyBuilder.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace ArmyBuilder.ViewModel
{
    public class MainViewModel : Observable
    {
        private static MainViewModel instance = new MainViewModel();
        private static readonly object padlock = new object();

        private readonly ArmybuilderContext _context = new();
        public ObservableCollection<Army> Armies { get; }
        public ObservableCollection<Detachment> Detachments { get; }
        public ObservableCollection<ArmyDetachment> Attachments { get; }
        public ObservableCollection<DetachmentUnit> DetachmentUnits { get; }
        public Dictionary<long, Faction> Factions { get; }
        public List<Unit> Units { get; }
        public ArmyFilter ArmyFilter { get; }

        private Army _selectedArmy;
        private Detachment _selectedDetachment;
        public bool IsArmySelected => _selectedArmy != null;


        MainViewModel()
        {
            Armies = new();
            Detachments = new();
            Attachments = new();
            Factions = new();
            Units = new();
            DetachmentUnits = new();
            ArmyFilter = new(Detachments, DetachmentUnits, Attachments, Units);
        }

        public static MainViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new MainViewModel();

                    return instance;
                }
            }
        }

        public Army SelectedArmy
        {
            get { return _selectedArmy; }
            set
            {   
                if(_selectedArmy != value)
                {
                    _selectedArmy = value;
                    ArmyFilter.FilterSelectedDetachments(_selectedArmy);
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsArmySelected));
                }
            }
        }

        public Detachment SelectedDetachment
        {
            get { return _selectedDetachment; }
            set
            {
                if( _selectedDetachment != value)
                {
                    _selectedDetachment = value;
                    ArmyFilter.FilterSelectedDetachmentUnits(_selectedDetachment);
                    OnPropertyChanged();
                }
            }
        }

        public void LoadArmies()
        {
            Armies.Clear();

            _context.Database.EnsureCreated();

            var allFactions = _context.Factions.ToDictionary(faction => faction.FactionId);
            var armies = _context.Armies.ToList();
            foreach (var arm in armies)
            {   
                if(allFactions.TryGetValue((long)arm.FkFactionId, out var Faction))
                {
                    arm.FkFaction = Faction;
                }
                Armies.Add(arm);
            }

            foreach(var faction in allFactions)
            {
                Factions.Add(faction.Key, faction.Value);
            }
        }

        public void LoadDetachments()
        {
            Detachments.Clear();
            _context.Database.EnsureCreated();
            var detachments = _context.Detachments.ToList();

            foreach(var  detachment in detachments)
            {
                Detachments.Add(detachment);
            }
        }

        public void LoadAttachments(ObservableCollection<Army> armiesList, ObservableCollection<Detachment> detachmentsList)
        {
            Attachments.Clear();
            _context.Database.EnsureCreated();
            var attachments = _context.ArmyDetachments.ToList();

            foreach(var attachment in attachments)
            {
                Attachments.Add(attachment);
                foreach(var detachment in detachmentsList)
                {
                    if(detachment.DetachmentId == attachment.DetachmentsDetachmentId)
                    {
                        attachment.DetachmentsDetachment = detachment;
                        break;
                    }
                }

                foreach(var army in armiesList)
                {
                    if(army.Id == attachment.ArmyId)
                    {
                        attachment.Army = army;
                        break;
                    }
                }   
            }
        }

        public void LoadUnits()
        {
            Units.Clear();
            _context.Database.EnsureCreated();
            var units = _context.Units.ToList();

            foreach(var unit in units)
            {
                Units.Add(unit);
            }
        }

        public void LoadDetachmentUnits(ObservableCollection<Detachment> detachmentList, List<Unit> unitList)
        {
            DetachmentUnits.Clear();
            _context.Database.EnsureCreated();
            var detachmentUnits = _context.DetachmentUnits.ToList();

            foreach(var detachmentUnit in detachmentUnits)
            {
                DetachmentUnits.Add(detachmentUnit);
                foreach(var unit in unitList)
                {
                    if(unit.UnitId == detachmentUnit.UnitId)
                    {
                        detachmentUnit.Unit = unit;
                        break;
                    }
                }
                foreach(var detachment in detachmentList)
                {
                    if(detachment.DetachmentId == detachmentUnit.DetachmentId)
                    {
                        detachmentUnit.Detachment = detachment;
                    }
                }
            }
        }
    }

}
