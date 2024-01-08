using PhotoBooth.Data.Models;

namespace PhotoBooth.Strategies;

public class HourlyVictoryStrategy : IVictoryStrategy
{
    private List<VictoryItem> _victoryItems;

    public HourlyVictoryStrategy()
    {
        _victoryItems = new List<VictoryItem>();
    }

    public bool IsLucky(string boothId)
    {
        bool isLucky = false;

        var victoryItem = _victoryItems.FirstOrDefault(item => item.BoothId == boothId);

        if (victoryItem == null) 
        {
            _victoryItems.Add(new VictoryItem 
            { 
                BoothId = boothId
            });

            isLucky = true;
        }
        else if((DateTime.UtcNow - victoryItem.LastWin).Hours >= 1)
        {
            victoryItem.LastWin = DateTime.UtcNow;
            isLucky = true;
        }

        return isLucky;
    }
}
