using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using idgag.GameState;
using System.Linq;

namespace idgag.WordGame {

    public class FuckBucketChoice : Choice
    {
        public FuckBucketChoice(string arg1, string arg2) : base() { initialize(); }
        public FuckBucketChoice(string arg1) : base() { initialize(); }
        public FuckBucketChoice() : base() { initialize();}

        private void initialize() {
            this.operation = ChoiceOperation.KEY;

            // Get fuck bucket names
            var values = Enum.GetValues(typeof(FuckBucketTarget)).Cast<FuckBucketTarget>();

            foreach (FuckBucketTarget fuckBucketTarget in values) {
                string label = Enum.GetName(typeof(FuckBucketTarget), fuckBucketTarget);
                Option newOption = new Option();
                newOption.value = (int)fuckBucketTarget;
               
                options.Add(label, newOption);

                if (this.currentChoice == null) {
                    this.currentChoice = newOption;
                }
            }
        }
    }

}
