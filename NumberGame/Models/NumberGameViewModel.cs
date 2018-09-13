using System;
using System.Web;

namespace NumberGame.Models {
    public class NumberGameViewModel {

        // Randomly generated number
        public int MyNumber { get; set; }

        // User's guess
        public int NumberGuess { get; set; }


        // Generate and assign our random number on model creation.
        public NumberGameViewModel() {
            Random rnd = new Random();
            this.MyNumber = rnd.Next(1, 100);
        }

    }
}
