using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace idgag.WordGame
{
    public class PRStatement
    {
        private Sentence prSentence;

        public PRStatement() {
            List<Sentence> sentences = Sentence.getSentences();

            System.Random r = new System.Random();

            while (prSentence == null) {
                int sentence = r.Next(0, sentences.Count);

                prSentence = sentences.ElementAt(sentence);
            }

        }

        public Sentence getSentence() {
            return prSentence;
        }
    }
}
