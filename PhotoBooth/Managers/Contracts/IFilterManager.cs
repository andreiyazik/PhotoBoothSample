namespace PhotoBooth.Managers.Contracts;

public interface IFilterManager<TInput, TOutput>
{
    TOutput ApplyFilters(TInput input);
}
