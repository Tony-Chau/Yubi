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

namespace UIPathCustom
{
    public class TextToSpeech : CodeActivity
    {

        [Category("Input")]
        public InArgument<int> Volume { get; set; }

        [Category("Input")]
        public InArgument<int> Rate { get; set; }

        [Category("Input")]
        public InArgument<string> Message { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Volume = Volume.Get(context);
            synth.Rate = Rate.Get(context);
            synth.Speak(Message.Get(context));
        }
    }
    public class SpeechToText : CodeActivity
    {
        [Category("Output")]
        public OutArgument<string> Message { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            DictationGrammar Grammar = new DictationGrammar();
            SpeechRecognitionEngine SpeechEngine = new SpeechRecognitionEngine();
            SpeechEngine.LoadGrammar(Grammar);
            SpeechEngine.SetInputToDefaultAudioDevice();
            Message.Set(context, SpeechEngine.Recognize().Text);

        }
    }
    public class PlaySound : CodeActivity
    {
        [Category("Input")]
        public InArgument<string> filepath { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string path = filepath.Get(context);
            SoundPlayer sound = new SoundPlayer(path);
            sound.Play();
        }
    }

}
