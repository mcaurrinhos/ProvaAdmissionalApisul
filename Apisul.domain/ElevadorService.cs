using Apisul.domain.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Apisul.domain
{
    public class ElevadorService : IElevadorService
    {
        #region Fields

        private List<Elevador> _Elevadores;

        #endregion

        #region Constructors

        public ElevadorService()
        {
            ImportarArquivoDados();
        }

        #endregion

        #region Private Methods

        private void ImportarArquivoDados()
        {
            string Json;

            try
            {
                Json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\input.json");
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao ler o arquivo de dados.", e);
            }

            try
            {
                _Elevadores = JsonConvert.DeserializeObject<List<Elevador>>(Json);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao desserializar o arquivo de dados.", e);
            }
        }

        private float _calculaPercentualUsoElevador(string elevador)
        {
            var usos = _Elevadores.Where(x => x.elevador.Equals(elevador)).ToList();
            var percUso = ((double)usos.Count / (double)_Elevadores.Count) * 100;

            return (float)Math.Round(percUso, 2);
        }

        #endregion

        #region Interface Methods

        /// <summary>
        /// Deve retornar uma List contendo o(s) andar(es) menos utilizado(s).
        /// </summary>
        /// <returns>Lista de andares ordenada pelo menor uso</returns>
        public List<int> andarMenosUtilizado()
        {
            var Retorno = new List<int>();

            var elevadores = _Elevadores.GroupBy(x => x.andar).OrderByDescending(x => x.Count());
            var usos = elevadores.Where(x => x.Count() <= 1).ToList();

            foreach (var item in usos)
            {
                Retorno.Add(item.Key);
            }

            return Retorno;
        }

        /// <summary>
        /// Deve retornar uma List contendo o(s) elevador(es) mais frequentado(s).
        /// </summary>
        /// <returns>Lista de elevadores ordenada pelo maior uso</returns>
        public List<char> elevadorMaisFrequentado()
        {
            var Retorno = new List<char>();

            var elevadores = _Elevadores.GroupBy(x => x.elevador).OrderByDescending(x => x.Count());
            var usos = elevadores.Where(x => x.Count() > 1).ToList();

            foreach (var item in usos)
            {
                Retorno.Add(Convert.ToChar(item.Key));
            }

            return Retorno;
        }

        /// <summary>
        /// Deve retornar uma List contendo o(s) elevador(es) menos frequentado(s).
        /// </summary>
        /// <returns>Lista de elevadores ordenada pelo menor uso</returns>
        public List<char> elevadorMenosFrequentado()
        {
            var Retorno = new List<char>();

            var elevadores = _Elevadores.GroupBy(x => x.elevador).OrderByDescending(x => x.Count());
            var usos = elevadores.Where(x => x.Count() <= 1).ToList();

            foreach (var item in usos)
            {
                Retorno.Add(item.Key[0]);
            }

            return Retorno;
        }

        /// <summary>
        /// Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador A em relação a todos os serviços prestados.
        /// </summary>
        /// <returns>Percentual de uso do elevador</returns>
        public float percentualDeUsoElevadorA()
        {
            return _calculaPercentualUsoElevador("A");
        }

        /// <summary>
        /// Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador B em relação a todos os serviços prestados.
        /// </summary>
        /// <returns>Percentual de uso do elevador</returns>
        public float percentualDeUsoElevadorB()
        {
            return _calculaPercentualUsoElevador("B");
        }

        /// <summary>
        /// Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador C em relação a todos os serviços prestados.
        /// </summary>
        /// <returns>Percentual de uso do elevador</returns>
        public float percentualDeUsoElevadorC()
        {
            return _calculaPercentualUsoElevador("C");
        }

        /// <summary>
        /// Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador D em relação a todos os serviços prestados.
        /// </summary>
        /// <returns>Percentual de uso do elevador</returns>
        public float percentualDeUsoElevadorD()
        {
            return _calculaPercentualUsoElevador("D");
        }

        /// <summary>
        /// Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador E em relação a todos os serviços prestados.
        /// </summary>
        /// <returns>Percentual de uso do elevador</returns>
        public float percentualDeUsoElevadorE()
        {
            return _calculaPercentualUsoElevador("E");
        }

        /// <summary>
        /// Deve retornar uma c de cada um dos elevadores mais frequentados (se houver mais de um).
        /// </summary>
        /// <returns></returns>
        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var Retorno = new List<char>();

            var elevadores = _Elevadores.GroupBy(x => x.elevador).OrderByDescending(x => x.Count());
            var usos = elevadores.Where(x => x.Count() > 1).ToList();

            foreach (var item in usos)
            {
                var uso = item.Where(x => x.turno != string.Empty).FirstOrDefault();
                Retorno.Add(Convert.ToChar(uso.turno));
            }
            return Retorno;
        }

        /// <summary>
        ///  Deve retornar uma List contendo o(s) periodo(s) de maior utilização do conjunto de elevadores.
        /// </summary>
        /// <returns></returns>
        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var Retorno = new List<char>();

            var elevadores = _Elevadores.GroupBy(x => x.turno).OrderByDescending(x => x.Count());
            var usos = elevadores.Where(x => x.Count() > 1).ToList();


            foreach (var item in usos)
            {
                Retorno.Add(Convert.ToChar(item.Key));
            }

            return Retorno;
        }

        /// <summary>
        /// Deve retornar uma List contendo o período de menor fluxo de cada um dos elevadores menos frequentados (se houver mais de um).
        /// </summary>
        /// <returns></returns>
        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var Retorno = new List<char>();

            var elevadores = _Elevadores.GroupBy(x => x.elevador).OrderByDescending(x => x.Count());
            var usos = elevadores.Where(x => x.Count() <= 1).ToList();

            foreach (var item in usos)
            {
                var saida = item.Where(x => x.turno != string.Empty).FirstOrDefault();
                Retorno.Add(saida.turno[0]);
            }

            return Retorno;
        }

        #endregion

    }
}
