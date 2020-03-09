using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using idgag.GameState;
using System.Linq;

namespace idgag.WordGame {

    public class NotFoundChoice : Choice
    {
        public NotFoundChoice(string arg1, string arg2) : base() { initialize(); }
        public NotFoundChoice(string arg1) : base() { initialize(); }
        public NotFoundChoice() : base() { initialize();}

        private void initialize() {
            this.operation = ChoiceOperation.ADD;

            // Create decreasing option
            Option notfound = new Option();
            notfound.value = 0;

            options.Add("PARAMETER NOT FOUND", notfound);

            if (this.currentChoice == null) {
                this.currentChoice = notfound;
            }

        }
    }

}
