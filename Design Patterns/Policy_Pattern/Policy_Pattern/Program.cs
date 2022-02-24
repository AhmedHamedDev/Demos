using Policy_Pattern;
using Policy_Pattern.Policies.Gender;
using Policy_Pattern.Policies.Temperature;
using Policy_Pattern.Policies.Universa;

List<IPackingItemsPolicy> _policies = new() { 
    new MaleGenderPolicy(), 
    new FemaleGenderPolicy(), 
    new HighTemperaturePolicy(), 
    new LowTemperaturePolicy(), 
    new BasicPolicy() 
};

var data = new PolicyData(5, Gender.Female, 10);
var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));

foreach (var item in items)
{
    Console.WriteLine(item);
}
