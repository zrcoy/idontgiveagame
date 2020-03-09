using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace idgag.WordGame
{
    public static class ChoiceFactory
    {
        public static Dictionary<string, System.Type> choices = new Dictionary<string, System.Type> {
            {"PERCENTAGE", typeof(PercentageChoice)},
            {"DIRECTION", typeof(DirectionChoice)},
            {"FUCKBUCKET", typeof(FuckBucketChoice)},
            {"UINTEGER", typeof(UIntegerChoice)},
            {"EXPECTATION", typeof(ExpectationsChoice)},
        };

        public static Choice getChoice(string token) {
            System.Type choiceType;

            Choice newChoice;

            List<string> args = parseArgs(token);

            if (args.Count == 0) {
                Debug.Log("Failed to parse token : " + token);
                return null;
            }

            if (!choices.TryGetValue(args[0], out choiceType)) {
                choiceType = typeof(NotFoundChoice);
            }

            try {
                if (args.Count > 2) {
                    newChoice = (Choice)System.Activator.CreateInstance(choiceType, args[1], args[2]);
                } else if (args.Count > 1) {
                    newChoice = (Choice)System.Activator.CreateInstance(choiceType, args[1]);
                } else {
                    newChoice = (Choice)System.Activator.CreateInstance(choiceType);
                }
            } catch (Exception e) {
                Debug.Log("Failed to initialize choice!: \n" + e.ToString());
                return null;
            }

            return newChoice;
        }

        private static List<string> parseArgs(string args) {
            string argString = args.TrimStart(new[] { '$', '{' }).TrimEnd(new[] { '}' });
            
            return (argString.Split(',')).OfType<string>().ToList();
        }
    }

}
