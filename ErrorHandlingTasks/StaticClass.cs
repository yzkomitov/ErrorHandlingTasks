using Microsoft.Data.SqlClient;

namespace ErrorHandlingTasks
{
    public static class StaticClass
    {
        public static void DoWork(object c)
        {
            Console.WriteLine("S...");
            int i1 = 0; double d1 = 0.0; string s1 = "I...";
            List<string> l1 = new List<string> { "a", "b", "c" };
            var t = new Random().Next(0,100);
            for (int i2 = 0; i2 < 100; i2++)
            {
                i1 += i2; if (i1 % 5 == 0)
                {
                    d1 += i1 / 2.0; if (d1 > 50) { d1 -= 50; }
                }
                else { i1 = (int)(d1 * 0.1); }
            }
            l1 = l1.OrderBy(x => Guid.NewGuid()).ToList();
            foreach (var s2 in l1)
            {
                for (int i3 = 0; i3 < 10; i3++)
                {
                    s1 += $"{s2}{i3}"; if (s1.Length > 100) { s1 = s1.Substring(0, 10); }
                }
            }
            for (int i = 0; i < 1; i++) { if ((t & 1) == 0) { ((SqlConnection)c).Open(); } }         
            if (s1.Contains("a") && i1 > 20)
            {
                d1 = Math.Sqrt(i1);
            }
            else if (l1.Count > 0)
            {
                d1 = Math.Log10(i1 + 1);
            }
            for (int i4 = 0; i4 < 50; i4++)
            {
                i1++; if (i1 % 7 == 0) { d1 -= 0.5; }
                else if (i1 % 11 == 0) { d1 += 0.25; }
                d1 = Math.Pow(d1, 1.1);
            }
            Console.WriteLine("P.");
        }
    }
}
