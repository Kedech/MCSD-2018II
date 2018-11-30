using System;
using System.Collections.Generic;
using System.Text;

namespace WebServerProj
{
    public class CustomArgs : EventArgs
    {
        public string ErrorMessage { get; set; }
    }

    public class HttpRequestConverter
    {

        public delegate void OnError(object obj, CustomArgs args);

        public event OnError OnRequestHeaderMissing;

        public byte[] AnalyzeRequest(System.Net.HttpListenerRequest request)
        {
            // Hacer algo con la conexion abierta.
            // Loguear el Request
            var requestInfo = $@"{request.RemoteEndPoint}-{request.HttpMethod}-{request.Url.AbsoluteUri}";
            Logger.Log(requestInfo, request.InputStream);

            // TODO: Revisar los Evaluadores de HTTP Headers
            List<IHttpHeaderEvaluator> listOfEvaluators = new List<IHttpHeaderEvaluator>(){
                //new AcceptEvaluator(),
                //new StudentEvaluator(),
                //new AcceptDatetimeEvaluator(),
            };


            // Como retornar archivos del servidor
            // Configurar una carpeta donde buscar archivos -> Appsettings.json
            // Analizar el URL para hacer match con los archivos de la carpeta
            byte[] encodedMessage = new byte[0];

            // Devuelve un mensaje de error del servidor web
            // Si los headers fallan al evaluar
            try
            {
                foreach (var evaluator in listOfEvaluators)
                {
                    evaluator.Evaluate(request.Headers);
                }

                /*
                foreach (var header in context.Request.Headers)
                {
                    HttpHeaderManager.ValidateHeaderName(header.ToString());
                }
                */

                Console.WriteLine($"LocalPath:{request.Url.LocalPath}");

                if (request.Url.LocalPath == "/")
                {
                    var fileManager = new FileManager(Options.Root);

                    List<string> files = fileManager.GetAllFiles();

                    ICustomBuilder indexPageBuilder = new IndexPageBuilder();
                    string response = indexPageBuilder.Build(files);

                    encodedMessage = Encoding.UTF8.GetBytes(response);
                }
                else
                {
                    try
                    {
                        var fileManager = new FileManager(Options.Root);
                        // Devuelve el archivo del disco duro.
                        encodedMessage = fileManager.GetFileByName(request.Url.LocalPath);
                    }
                    catch
                    {
                        // Lanzar error 404
                    }
                }
            }
            catch (Exception ex)
            {
                OnRequestHeaderMissing(ex, new CustomArgs()
                {
                    ErrorMessage = ex.Message + Environment.NewLine + ex.StackTrace
                });
                encodedMessage = Encoding.UTF8.GetBytes(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            return encodedMessage;
        }
    }
}