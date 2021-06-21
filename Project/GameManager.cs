using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    class GameManager
    {
        private Players players;
        public string input;
        string input1;
        public GameManager(Players players)
        {
            this.players = players;
        }
        public void Run(View view)
        {
            view.sos();
            do
            {
                input1 = view.takinginput(input);

                switch (input1)
                {
                    case "play":
                        players.Deal();// to play the game
                        Play(view);
                        break;

                    case "show": // to show main menu again
                        view.sos();
                        break;

                    case "help": // this thing is nothing for now i was just testing something
                        break;

                    case "quit":
                        System.Environment.Exit(0);
                        break;
                }
            } while (input1 != "quit");
        }

        public void Play(View view)
        {
            view.PlayMenu();
            do
            {
                input1 = view.takinginput(input);

                switch (input1)
                {
                    case "1st":
                        view.PlayMenu();
                        break;

                    case "show": // to show main menu again
                        view.sos();
                        break;

                    case "help": // this thing is nothing for now i was just testing something
                        break;

                    case "back":
                        Run(view);
                        break;
                }
            } while (input1 != "back");
        }
    }
}