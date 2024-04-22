using ClassLibraryLabor10;
using System.ComponentModel.Design;

namespace laba12._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<Musicalinstrument> list = new MyList<Musicalinstrument>();
            int answer = 1;
            while (answer !=6)
            {
                try
                {
                    PrintMenu(menu);
                    answer = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}
