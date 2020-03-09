using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace idgag.WordGame {

    public enum ChoiceOperation
    {
        MULT,
        ADD,
        KEY
    }

    public class Option
    {
        public int value;
    }

    public abstract class Choice
    {
        public Dictionary<string, Option> options;
        protected ChoiceOperation operation;
        protected Option currentChoice;

        public Choice() {
            options = new Dictionary<string, Option>();
        }

        public Option getCurrentChoice() {
            return currentChoice;
        }

        public ChoiceOperation GetOperation() {
            return operation;
        }

        public void ChooseOption(string key) {
            if (!options.ContainsKey(key)) {
                Debug.Log("Invalid choice");
                return;
            }

            currentChoice = options[key];
        }


    }

}
