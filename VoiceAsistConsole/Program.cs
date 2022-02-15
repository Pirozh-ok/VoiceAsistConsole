using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VoiceAsistConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            VoiceComand obg = new VoiceComand();
            Console.ReadKey(); 
        }
    }
}

//основные функции
// -сколько время, какое число
// открой: -блокнот, браузер, калькулятор
// закрой - закрывает последний запущенный процесс
// какая погода
