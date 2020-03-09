using System;
using System.Collections.Generic;
using System.Linq;
using idgag.GameState;
using System.IO;
using UnityEngine;

namespace idgag.WordGame
{
    public struct FucksBucketMod
    {
        public int baseChange;
        public int modifier;
        public FuckBucketTarget fucksBucketKey;
    }

    public class Sentence
    {
        public static string FILE_PATH = "Assets/Config/whatigiveafuckabout.txt";

        List<Word> words = new List<Word>();

        public Sentence(string sentence) {
            if (sentence == null || sentence == "") return;

            words = new List<Word>();

            foreach (string word in parseWords(sentence)) {
                if (word == null) continue;

                // handle word
                // is it a token
                words.Add(new Word(word));
            }

        }

        public List<Word> getWords() {
            return words;
        }

        public List<FucksBucketMod> CalculateFuckBuckets() {
            // Get List of choices
            List<FucksBucketMod> mods = new List<FucksBucketMod>();

            FucksBucketMod mod;
            mod.baseChange = 0;
            mod.fucksBucketKey = FuckBucketTarget.Economy;
            mod.modifier = 1;

            foreach (Word word in words) {
                if (word.isOption()) {
                    Choice choice = word.getChoice();
                    switch (choice.GetOperation()) {
                        case ChoiceOperation.ADD: {
                                mod.baseChange += choice.getCurrentChoice().value;
                                
                                break;
                            }
                        case ChoiceOperation.MULT: {
                                mod.modifier *= choice.getCurrentChoice().value;
                                
                                break;

                            }
                        case ChoiceOperation.KEY: {
                                mod.fucksBucketKey = (FuckBucketTarget)choice.getCurrentChoice().value;
                            break;
                        }
                        default:
                            Debug.Log("Operation not found");
                            break;
                    }

                }
            }

            mods.Add(mod);

            // Apply the calculation
            return mods;
        }

        private static List<string> parseWords(string sentence) {
            string[] words = sentence.Split(' ');
            return words.OfType<string>().ToList();
        }

        public void ChooseOption(int index, string option) {
            Word word = words.ElementAt(index);

            if (word != null) {
                if (word.isOption()) {
                    word.getChoice().ChooseOption(option);
                }
                
            }
        }
        public static List<Sentence> getSentences() {
            FileInfo source = new FileInfo(FILE_PATH);
            StreamReader reader = source.OpenText();
            string text = "";

            List<Sentence> allSentences = new List<Sentence>();

            while (text != null) {
                text = reader.ReadLine();
                if (text == null) continue;

                Sentence newSentence = new Sentence(text);
                if (newSentence != null) allSentences.Add(newSentence);
            }

            return allSentences;
        }
    }
}
