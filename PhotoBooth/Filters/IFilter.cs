namespace PhotoBooth.Filters;

public interface IFilter<TInput, TOutput>
{
    TOutput ApplyTo(TInput input);
}
