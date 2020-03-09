using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace idgag.WordGame {

    public class PercentageChoice : Choice
    {
        public PercentageChoice(string min, string max) : base() {
            this.operation = ChoiceOperation.ADD;

            int minimum = 0;
            int maximum = 100;

            Int32.TryParse(max, out maximum);

            initialize(minimum, maximum);

        }

        public PercentageChoice(string max) : base() {
            int minimum = 0;
            int maximum = 100;

            Int32.TryParse(max, out maximum);

            initialize(minimum, maximum);
        }

        public PercentageChoice() : base() {
            int minimum = 0;
            int maximum = 100;

            initialize(minimum, maximum);
        }

        void initialize(int minimum, int maximum) {
            operation = ChoiceOperation.ADD;

            maximum = Mathf.Clamp(maximum, 0, 100);

            int numberOfOptions = 10;
            int spreadPerOption = (maximum - minimum) / numberOfOptions;
            for (int i = 1; i < numberOfOptions + 1; i++) {
                Option newOption = new Option();
                int label = minimum + (i * spreadPerOption);

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
