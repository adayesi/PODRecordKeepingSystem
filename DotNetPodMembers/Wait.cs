using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodMembersRecordUI
{
    public static class Wait
    {
        public static void Waiting()
        {
            int times = 1;
            Console.Clear();
            while (times > 0)
            {
                Console.Out.Write("Please wait");
                char[] anim = new char[3] { '.', '.', '.' };
                Console.Out.Flush();
                for (int i = 0; i < anim.Length; i++)
                {
                    Console.Out.Write(anim[i % anim.Length]);
                    Console.Out.Flush();
                    Thread.Sleep(1000);

                }
                Console.Clear();
                times--;
            }
        }
    }
}
