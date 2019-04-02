using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Media;
using System.IO;

using MySql.Data.MySqlClient;

namespace UIPathCustom
{
    /// <summary>
    /// Text to speech activity
    /// </summary>
    public class TextToSpeech : CodeActivity
    {
        /// <summary>
        /// Volume of the voice
        /// </summary>
        [Category("Input")]
        public InArgument<int> Volume { get; set; }

        /// <summary>
        /// The rate of the voice (must be value between -10 to 10)
        /// </summary>
        [Category("Input")]
        public InArgument<int> Rate { get; set; }

        /// <summary>
        /// The message the voice will say
        /// </summary>
        [Category("Input")]
        public InArgument<string> Message { get; set; }

        /// <summary>
        /// The execution of the voice
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(CodeActivityContext context)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Volume = Volume.Get(context);
            synth.Rate = Rate.Get(context);
            synth.Speak(Message.Get(context));
        }
    }

    /// <summary>
    /// Playing the Wav sound activity
    /// </summary>
    public class PlaySound : CodeActivity
    {
        /// <summary>
        /// The path to the wav file
        /// </summary>
        [Category("Input")]
        public InArgument<string> filepath { get; set; }

        /// <summary>
        /// Execution of the wav file
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(CodeActivityContext context)
        {
            string path = filepath.Get(context);
            SoundPlayer sound = new SoundPlayer(path);
            sound.Play();
        }
    }

    /// <summary>
    /// Sorting out the spelling of the word the user is saying
    /// </summary>
    public class SortSpellLetters : CodeActivity
    {
        /// <summary>
        /// The spelled out world that will be fixed up
        /// </summary>
        [Category("Input")]
        public InArgument<string> SpelledOutWord { get; set; }

        /// <summary>
        /// The fixed up text
        /// </summary>
        [Category("Output")]
        public OutArgument<string> Result { get; set; }

        /// <summary>
        /// The execution of the spelled out word
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(CodeActivityContext context)
        {
            string word = SpelledOutWord.Get(context);
            word = word.ToLower();
            word = word.Replace("dot", ".");
            word = word.Replace("period", ".");
            word = word.Replace("dash", "-");
            word = word.Replace("divide", "/");
            word = word.Replace("slash", "/");
            word = word.Replace("minus", "-");
            word = word.Replace("subtract", "-");
            word = word.Replace("plus", "+");
            word = word.Replace("add", "+");
            word = word.Replace("hash", "#");
            word = word.Replace("sharp", "#");
            word = word.Replace("mutiply", "*");
            word = word.Replace("asterisk", "*");
            word = word.Replace("under score", "_");
            word = word.Replace("at", "@");

            word = word.Replace(" ", "");
            word = word.Replace("space", " ");
            Result.Set(context, word);
        }
    }
}
