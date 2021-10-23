namespace GameOfLife.Core.Engine.Rules
{
    public class DeadCellRule : ICellRule
    {
        public bool ShouldLive(int liveNeighboursCount)
        {
            return liveNeighboursCount == 3;
        }
    }
}