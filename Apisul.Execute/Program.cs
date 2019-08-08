using Apisul.domain;
using Apisul.domain.Interface;
using System;

namespace Apisul.Execute
{
    class Program
    {
   
         static void Main(string[] args)
        {
            var service = new ElevadorService();

            var andarMenosUtilizado = service.andarMenosUtilizado();
            var elevadorMaisFrequentado = service.elevadorMaisFrequentado();
            var elevadorMenosFrequentado = service.elevadorMenosFrequentado();
            var percentualDeUsoElevadorA = service.percentualDeUsoElevadorA();
            var percentualDeUsoElevadorB = service.percentualDeUsoElevadorB();
            var percentualDeUsoElevadorC = service.percentualDeUsoElevadorC();
            var percentualDeUsoElevadorD = service.percentualDeUsoElevadorD();
            var percentualDeUsoElevadorE = service.percentualDeUsoElevadorE();
            var periodoMenorFluxoElevadorMenosFrequentado = service.periodoMenorFluxoElevadorMenosFrequentado();
            var periodoMaiorFluxoElevadorMaisFrequentado = service.periodoMaiorFluxoElevadorMaisFrequentado();
            var periodoMaiorUtilizacaoConjuntoElevadores  = service.periodoMaiorUtilizacaoConjuntoElevadores();

            Console.WriteLine("\nAndares menos utilizados:");
            andarMenosUtilizado.ForEach(i => Console.Write("{0}\t",i));
            Console.WriteLine();

            Console.WriteLine("\nElevadores mais frequentados:");
            elevadorMaisFrequentado.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine();

            Console.WriteLine("\nElevadores menos frequentados:");
            elevadorMenosFrequentado.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine();

            Console.WriteLine("\nPercentual no uso do elevador A: {0} %", percentualDeUsoElevadorA);
            Console.WriteLine("\nPercentual no uso do elevador B: {0} %", percentualDeUsoElevadorB);
            Console.WriteLine("\nPercentual no uso do elevador C: {0} %", percentualDeUsoElevadorC);
            Console.WriteLine("\nPercentual no uso do elevador D: {0} %", percentualDeUsoElevadorD);
            Console.WriteLine("\nPercentual no uso do elevador E: {0} %", percentualDeUsoElevadorE);

            Console.WriteLine("\nPeriodo de Menor Fluxo dos elevadores menos frequentados:");
            periodoMenorFluxoElevadorMenosFrequentado.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine();

            Console.WriteLine("\nPeriodo de Maior Fluxo dos elevadores mais frequentados:");
            periodoMaiorFluxoElevadorMaisFrequentado.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine();

            Console.WriteLine("\nPeriodo de Maior Utilização do conjunto de Elevadores:");
            periodoMaiorUtilizacaoConjuntoElevadores.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
