using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace idgag.WordGame {

    public class UIntegerChoice : Choice
    {

        public UIntegerChoice(string min, string max) : base() {

            int minimum = 0;
            int maximum = 100;
            Int32.TryParse(max, out maximum);
            Int32.TryParse(min, out minimum);

            initialize(minimum, maximum);
        }

        public UIntegerChoice(string min) : base() {

            int minimum = 0;
            int maximum = 100;
            Int32.TryParse(min, out minimum);

            initialize(minimum, maximum);
        }

        public UIntegerChoice() : base() {
            this.operation = ChoiceOperation.ADD;

            int minimum = 0;
            int maximum = 100;

            initialize(minimum, maximum);
        }

        void initialize(int minimum, int maximum) {
            this.operation = ChoiceOperation.ADD;


            int numberOfOptions = 10;
            int spreadPerOption = (maximum - minimum) / numberOfOptions;

            for (int i = 0; i < numberOfOptions; i++) {
                Option newOption = new Option();
                float label = (float)Mathf.Clamp(minimum + (i * spreadPerOption), minimum, maximum);
                newOption.value = i / 2;


                if (!options.ContainsKey(label.ToString())) {
                    options.Add(label.ToString(), newOption);
                }

                if (this.currentChoice == null) {
                    this.currentChoice = newOption;
                }
            }


            if (!options.ContainsKey(maximum.ToString())) {
                Option newOption = new Option();
                newOption.value = 5;

                options.Add(maximum.ToString(), newOption);
            }
        }
    }

}
