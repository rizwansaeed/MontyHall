using System;
using System.CodeDom;
using System.Collections.Generic;

namespace MontyHall
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var m = ~0 << 3;
            
            var rnd = new Random();
            
            var stick = 0.0;
            var twist = 0.0;
            var n = 10000000;
            
            var states = new[] {0b100, 0b010, 0b001};

            for (var i = 0; i < n; i++)
            {
                var win = states[rnd.Next(0, 3)];
                var player = 1 << rnd.Next() % 3;
                var opened = 0;
    
                if (player == win)
                {
                    do
                    {
                        opened = 1 << (rnd.Next() % 3) & (~win - m);
                    } while (opened == 0);
                }
                else
                {
                    opened = (win | player) ^ 0b111;
                }                                             
             
                var option = ~(player | opened) - m;
                
                /*Console.WriteLine($"win    : {Convert.ToString(win, 2).PadLeft(3, '0')}");
                Console.WriteLine($"player : {Convert.ToString(player, 2).PadLeft(3, '0')}");
                Console.WriteLine($"opened : {Convert.ToString(host, 2).PadLeft(3, '0')}");
                Console.WriteLine($"option : {Convert.ToString(option, 2).PadLeft(3, '0')}");*/
                
                if ((player & win) > 0)
                {
                    stick += 1;
                    //Console.WriteLine("stick");
                }
                else if ((option & win) > 0)
                {
                    twist += 1;
                    //Console.WriteLine("twist");
                }
                else
                {
                    //Console.WriteLine("lost");
                }
                
                //Console.WriteLine("---");
                
            }
            
            Console.WriteLine($"stick: {String.Format("{0:F}", stick/n)}");
            Console.WriteLine($"twist: {String.Format("{0:F}", twist/n)}");
        }
    }
}
