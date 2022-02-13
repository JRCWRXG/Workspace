using FileHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IN100_INSS
{

    public class Config
    {
        // public string Tipo { get; set; }

        [FieldFixedLength(10)]
        public string Arquivo_origem { get; set; }

        [FieldFixedLength(10)]
        public string Arquivo_destino { get; set; }

        [FieldFixedLength(10)]
        public string Path_origem { get; set; }

        [FieldFixedLength(10)]
        public string Path_destino { get; set; }


        [FieldFixedLength(100)]
        public string log { get; set; }

        [FieldFixedLength(10)]
        public string usuario { get; set; }

        [FieldFixedLength(10)]
        public string bkp { get; set; }

        [FieldFixedLength(10)]

        public string ConectarExcel { get; set; }

        public int Total_Lote { get; set; }


        [FieldFixedLength(10)]
        public string timeStamp { get; set; }

        public string pasta { get; set; }



        public List<Config> listaDeConfiguracao()
        {
            List<Config> Settings = new List<Config>();

            try

            {
                var listaConfig = new List<Config>();
                var _listaConfig = new Config

                {
                    //  Tipo = ConfigurationManager.AppSettings["Tipo"],
                    Arquivo_origem = ConfigurationManager.AppSettings["Arquivo_origem"],
                    Arquivo_destino = ConfigurationManager.AppSettings["Arquivo_destino"],
                    Path_origem = ConfigurationManager.AppSettings["Path_origem"],
                    Path_destino = ConfigurationManager.AppSettings["Path_destino"],
                    log = ConfigurationManager.AppSettings["log"],
                    bkp = ConfigurationManager.AppSettings["bkp"],
                    Total_Lote = Convert.ToInt32(ConfigurationManager.AppSettings["Total_Lote"]),
                    ConectarExcel = ConfigurationManager.ConnectionStrings["ConectarExcel"].ConnectionString,
                    usuario = System.Environment.UserName,
                    timeStamp = Timestamp(DateTime.Now)

                };

                Settings.Add(_listaConfig);


            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Settings;
        }

        public void gravarLog(int totalRegistros, List<Config> _listaConfig)
        {
            using (StreamWriter sw = new StreamWriter(_listaConfig[0].log, true))
            {
                DateTime data = DateTime.Now;

                sw.WriteLine("Data: " + data + "  - ID: " + _listaConfig[0].timeStamp + " -   Usuário: " + _listaConfig[0].usuario + "   - Total de registros gravados: " + totalRegistros);

            }

        }


        public void gravarLog(string erro, List<Config> _listaConfig)
        {
            using (StreamWriter sw = new StreamWriter(_listaConfig[0].log, true))
            {
                DateTime data = DateTime.Now;

                sw.WriteLine("Data: " + data + "  - ID: " + _listaConfig[0].timeStamp + "   - Usuário: " + _listaConfig[0].usuario + " - erro: " + erro);

            }

        }


        public String Timestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }


        public bool moverArquivo(List<Config> _listaConfig)
        {

            CopiarArquivos(_listaConfig);
            ListarArquivos(_listaConfig);
            ListarPastas(_listaConfig);

            if (Directory.Exists(_listaConfig[0].Path_origem))
            {

                string strDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")).Replace(":", "");

                string origem = _listaConfig[0].Path_origem + _listaConfig[0].Arquivo_destino + "_*.txt";
                string destino = _listaConfig[0].bkp + "rtlib_" + strDate + ".txt";

                //   File.Copy(origem, destino, true);


            }

            return true;
        }



        public List<string> ListarPastas(List<Config> _listaConfig)
        {
            var Diretorios = Directory.GetDirectories(_listaConfig[0].Path_origem);

            List<string> listaPastas = new List<string>();

            foreach (var Dir in Diretorios)
            {
                listaPastas.Add(Dir);
            }

            return listaPastas;
        }


        public List<string> ListarArquivos(List<Config> _listaConfig)
        {
            try
            {
                var Arquivos = Directory.GetFiles(_listaConfig[0].Path_origem);

                List<string> listasArquivos = new List<string>();

                foreach (var Arq in Arquivos)
                {
                    listasArquivos.Add(Arq);
                }

                return listasArquivos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public void CopiarArquivos(List<Config> _listaConfig)
        {

            try
            {
                ValidaDiretorio(_listaConfig[0].bkp);

                string strDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")).Replace(":", "");
                var arquivos = Directory.GetFiles(_listaConfig[0].Path_origem);
                var arqDestino = "";

                foreach (var arqOrigem in arquivos)
                {
                    arqDestino = Path.GetFileName(arqOrigem);
                    File.Copy(arqOrigem, _listaConfig[0].bkp + "\\" + arqDestino.Remove(arqDestino.Length - 4, 3) + "_" + strDate + ".txt", true);
                    //File.Move(arqOrigem, _listaConfig[0].bkp + "\\" + arqDestino.Remove(arqDestino.Length - 4, 4) + "_" + strDate + ".txt");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void ValidaDiretorio(string pasta)
        {
            try
            {
                if (!Directory.Exists(pasta))
                {
                    Directory.CreateDirectory(pasta);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public void ExcluirArquivo(string arquivo)
        {
            try
            {
                if (File.Exists(arquivo))
                {
                    File.Delete(arquivo);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
