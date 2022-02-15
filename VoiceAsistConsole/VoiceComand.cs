using System;
using System.Collections.Generic;
using Microsoft.Speech.Recognition.SrgsGrammar;
using Microsoft.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Diagnostics;

namespace VoiceAsistConsole
{
    public class VoiceComand
    {
        string _pathGram = @"C:\Users\ivan-\source\repos\VoiceAsistConsole\VoiceAsistConsole\";
        Process _currentProcess;
        string _nameCurProcess;
        Choices _comands;
 
        Grammar _grammar;
        SpeechSynthesizer _speech = new SpeechSynthesizer();
        SpeechRecognitionEngine _speechEg = new SpeechRecognitionEngine(
                                            new System.Globalization.CultureInfo("ru-RU"));

        List<string> listCommands = new List<string>();
        public List<string> ListCommands { get => listCommands; }

        public VoiceComand()
        {
            _speech.Volume = 100;
            _speech.Rate = 0;

            /*FileStream fs = new FileStream(_pathGram + "VoiceGrammar.cfg", FileMode.Create);
            SrgsGrammarCompiler.Compile(_pathGram + "VoiceGrammar.xml", fs);
            fs.Close();
            _grammar = new Grammar(_pathGram + "VoiceGrammar.cfg", "Voice");*/

            Choices comands = new Choices();
            comands.Add(new string[] { "открой калькулятор", "покажи", "какое время" });
            GrammarBuilder gb = new GrammarBuilder() { Culture = new System.Globalization.CultureInfo("ru-RU") };
            gb.Append(comands);
            _grammar = new Grammar(gb);
            
            _speechEg.LoadGrammar(_grammar);
            _speechEg.SetInputToDefaultAudioDevice();
            _speechEg.RecognizeAsync(RecognizeMode.Multiple);
            _speechEg.SpeechRecognized += SpeechEg_SpeechRecognized;
        }

        /*Обработка распознаной команды*/
        private void SpeechEg_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
           if (e.Result.Confidence > 0.82)
            {
                /*string readCom = e.Result.Semantics["cmd"].Value.ToString();
                string readProc = e.Result.Semantics["showObj"].Value.ToString();*/
                Console.WriteLine(e.Result.Confidence.ToString() + " " + e.Result.Text);

                switch (e.Result.Text)
                {
                    case "покажи": 
                        {
                            _speech.SpeakAsync("показываю");
                            break; 
                        }
                    case "открой блокнот":
                        {
                            _speech.SpeakAsync("уже открываю");
                            _currentProcess = Process.Start("notepad");
                            Console.WriteLine(_currentProcess.GetType().ToString());
                            _nameCurProcess = "блокнот"; 
                            break;
                        }
                    case "закрой":
                        {
                            if (_currentProcess != null)
                            {
                                _speech.SpeakAsync("закрываю " + _nameCurProcess);
                                _currentProcess.Kill(); 
                                *//*foreach (Process process in Process.GetProcesses())
                                {
                                    // выводим id и имя процесса
                                    Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");
                                }*//*
                                _nameCurProcess = string.Empty;
                                _currentProcess = null;
                            }
                            else _speech.SpeakAsync("чтобы закрыть надо что-то открыть");
                            break;
                        }
                    default: break; 
                }*/
                // _speech.SpeakAsync(e.Result.);
          //  }
        }
    }
}
