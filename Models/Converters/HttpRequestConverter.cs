using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Linq;

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

        public byte[] AnalyzeRequest(HttpListenerRequest request)
        {
            // Hacer algo con la conexion abierta.
            // Loguear el Request
            var requestInfo = $@"{request.RemoteEndPoint}-{request.HttpMethod}-{request.Url.AbsoluteUri}";
            Logger.Log(requestInfo, request.InputStream);

            // TODO: Revisar los Evaluadores de HTTP Headers
            List<IHttpHeaderEvaluator> listOfEvaluators = new List<IHttpHeaderEvaluator>(){
                new AcceptEvaluator(),
                new StudentEvaluator(),
                new AcceptDatetimeEvaluator(),
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

                foreach (var header in request.Headers)
                {
                    HttpHeaderManager.ValidateHeaderName(header.ToString());
                }                

                Console.WriteLine($"LocalPath:{request.Url.LocalPath}");
                
                ICustomBuilder indexPageBuilder = new IndexPageBuilder();
                if (request.Url.LocalPath == "/")
                {
                    var fileManager = new FileManager(Options.Root);

                    List<string> files = fileManager.GetAllFiles();
                    List<string> directories = fileManager.GetAllDirectories();
                    List<string> all  = new List<string>();

                    all = files.Concat(directories).ToList();
                    
                    string response = indexPageBuilder.Build(all);

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
                    catch(FileNotFoundException ex)
                    {
                        string msg = ex.FileName;
                        string responseNotFound = indexPageBuilder.PageNotFound(msg);
                        encodedMessage = Encoding.UTF8.GetBytes(responseNotFound);
                        //throw new FileNotFoundException("archivo no encontrado");
                    }
                    catch(WebException ex)
                    {
                        var response = (HttpWebResponse)ex.Response;

                        switch (response.StatusCode)
                        {
                            case HttpStatusCode.NotFound: 
                                string notfound = "<!DOCTYPE Html><html><head><title>"+response.StatusCode+"</title></head><body><h1>404 </h1> <h2>"+response.StatusDescription+"</h2></body></html>";
                                encodedMessage = Encoding.UTF8.GetBytes(notfound);
                                break;

                            case HttpStatusCode.InternalServerError: 
                                string internalError = "<!DOCTYPE Html><html><head><title>"+response.StatusCode+"</title></head><body><h1>404 </h1> <h2>"+response.StatusDescription+"</h2></body></html>";
                                encodedMessage = Encoding.UTF8.GetBytes(internalError);
                                break;

                            default:
                                throw;
                        }
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