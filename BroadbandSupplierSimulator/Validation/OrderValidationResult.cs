namespace BroadbandSupplierSimulator.Validation;

public class OrderValidationResult
{
    private readonly List<string> errors = [];

    public IReadOnlyList<string> Errors => errors;

    public bool IsValid => errors.Count == 0;

    public void AddError(string error)
    {
        errors.Add(error);
    }

    public void Merge(OrderValidationResult other)
    {
        errors.AddRange(other.Errors);
    }
}
