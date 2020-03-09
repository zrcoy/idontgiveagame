using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using idgag.GameState;
using System.Linq;

namespace idgag.WordGame {

    public class ExpectationsChoice : Choice
    {
        public ExpectationsChoice(string arg1, string arg2) : base() { initialize(); }
        public ExpectationsChoice(string arg1) : base() { initialize(); }
        public ExpectationsChoice() : base() { initialize();}

        private void initialize() {
            this.operation = ChoiceOperation.MULT;

            Option great = new Option();
            great.value = 2;
            options.Add("great", great);

            Option good = new Option();
            good.value = 1;
            options.Add("good", good);

            Option okay = new Option();
            okay.value = 0;
            options.Add("okay", okay);

            Option poor = new Option();
            poor.value = -1;
            options.Add("poor", poor);

            Option terrible = new Option();
            terrible.value = -2;
            options.Add("terrible", terrible);

            if (this.currentChoice == null) {
                this.currentChoice = great;
            }
        }
    }

}
