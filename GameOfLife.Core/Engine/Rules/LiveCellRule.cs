namespace GameOfLife.Core.Engine.Rules
{
    public class LiveCellRule : ICellRule
    {
        public bool ShouldLive(int liveNeighboursCount)
        {
            return liveNeighboursCount == 2 || liveNeighboursCount == 3;
        }
    }
}