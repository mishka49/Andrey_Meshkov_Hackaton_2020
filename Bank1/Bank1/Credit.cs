using System;

namespace Bank1
{
    class Credit
    {
        public string Status { get; set; }
        public double Total { get; set; }
        public double Percent { get; }
        public double PeriodOfTime { get; set; }

        public Credit(double total, double periodOfTime)
        {
            Percent = 20;
            Status = "norepaid";
            Total = total;
            PeriodOfTime = periodOfTime;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Status: " + Status);
            Console.WriteLine("Total: " + Total);
            Console.WriteLine("Percent: " + Percent);
            Console.WriteLine("Period of time: " + PeriodOfTime);
        }
    }
}
