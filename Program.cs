using System;

namespace CAB301
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initilise the menu
           Menu menu = new Menu();

            // Display main menu
            menu.Main();
            if (menu.getInput() == 1)
            {
                menu.staff();
                if (menu.getInput() == 0)
                {
                    menu.Main();
                }

            } else if (menu.getInput() == 2) 
            {
                menu.member();

            } else if ( menu.getInput() == 0)
            {
                Environment.Exit(0);
            }
        }
    }
}
