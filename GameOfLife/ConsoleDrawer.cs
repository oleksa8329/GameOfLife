using System;

namespace GameOfLife
{
    public class ConsoleDrawer
    {
        private readonly int HeaderHeight = 1;

        public void Clear()
        {
            Console.Clear();
            Console.CursorVisible = false;
        }

        public void SetHeaderText(string text)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(text);
        }

        public void DrawBox(int x, int y)
        {
            Console.SetCursorPosition(x, y + HeaderHeight);
            Console.Write('\u2588');
        }
    }
}
