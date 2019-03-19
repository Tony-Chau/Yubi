using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {/*
            SpeechRecognizer recon = new SpeechRecognizer();
            Choices choice = new Choices();
            choice.Add(new string[] { "red", "green", "blue" });
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(choice);

            Grammar g = new Grammar(gb);
            gb.Culture = Thread.CurrentThread.CurrentCulture;
            recon.LoadGrammar(g);
            recon.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecongnized);
            Console.ReadKey();*/

            SpeechRecognizer recon = new SpeechRecognizer();
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Volume = 100;
            synth.Rate = 0;
            synth.Speak("Say Something now");

            DictationGrammar Grammar = new DictationGrammar();
            SpeechRecognitionEngine SpeechEngine = new SpeechRecognitionEngine();
            SpeechEngine.LoadGrammar(Grammar);
            recon.LoadGrammar(Grammar);
            recon.SpeechRecognized += EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecongnized);
            /*
            SpeechEngine.SetInputToDefaultAudioDevice();
            var sp = SpeechEngine.Recognize();
            Console.WriteLine(sp.Text);*/

            Console.ReadKey();
            
        }

        private static EventHandler<T> EventHandler<T>(Action<object, T> sre_SpeechRecongnized)
        {
            throw new NotImplementedException();
        }

        private static void sre_SpeechRecongnized(object arg1, SpeechRecognizedEventArgs arg2)
        {
            Console.WriteLine(arg2.ToString());
        }


    }
}
