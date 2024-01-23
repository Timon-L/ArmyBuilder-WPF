using ArmyBuilder.Base;
using ArmyBuilder.Models;

namespace ArmyBuilder.ViewModel
{
    public class ModelViewModel : Observable
    {
        public Dictionary<long, Model> Model_dic { get; } = new();

        public void LoadModels(ArmybuilderContext _context, Dictionary<long, Unit> Units_dic)
        {
            Model_dic.Clear();

            var models = _context.Models.ToList();
            foreach (var model in models)
            {
                if(model.FkUnitId.HasValue && Units_dic.TryGetValue(model.FkUnitId.Value, out var tmpUnit))
                {
                    model.FkUnit = tmpUnit;
                    Model_dic[model.ModelId] = model;
                }
            }
        }
    }
}
