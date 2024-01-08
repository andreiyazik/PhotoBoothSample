namespace TaxViewer.Managers;

public interface ITaxManager
{
    decimal CalculateTax(int month, int year);
}
