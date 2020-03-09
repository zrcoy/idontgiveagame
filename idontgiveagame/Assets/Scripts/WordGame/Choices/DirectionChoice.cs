using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using idgag.GameState;
using System.Linq;

namespace idgag.WordGame {

    public class DirectionChoice : Choice
    {
        public DirectionChoice(string arg1, string arg2) : base() { initialize(); }
        public DirectionChoice(string arg1) : base() { initialize(); }
        public DirectionChoice() : base() { initialize();}

        private void initialize() {
            this.operation = ChoiceOperation.MULT;

            // Create decreasing option
            Option decreasing = new Option();
            decreasing.value = -1;

            options.Add("decrease", decreasing);

            Option increasing = new Option();
            increasing.value = 1;

            options.Add("increase", increasing);

            if (this.currentChoice == null) {
                this.currentChoice = decreasing;
            }
        }
    }

}
