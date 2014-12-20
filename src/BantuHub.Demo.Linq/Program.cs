using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BantuHub.Demo.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var nombres = Enumerable.Range(1, 100);

            var nombresPairs = from nombre in nombres
                where nombre%2 == 0
                select nombre;

            foreach (var nombresPair in nombresPairs)
            {
                Console.WriteLine(nombresPair);
            }

            Console.Read();
        }
    }
}
