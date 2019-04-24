using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduIDDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            string UUID = eduid.GenerateShanghaiEduID("110101200101016874");
            Console.WriteLine(UUID);
        }
    }
}
