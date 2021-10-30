using System;

namespace Topicos.NetCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HagaLaMagia();
        }

        private static void HagaLaMagia()
        {
            var laMagia = new LogicaPrincipal();
            laMagia.HagaLaMagia();
        }
    }
}
