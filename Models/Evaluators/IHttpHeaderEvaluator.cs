using System.Collections.Specialized;
using System;

namespace WebServerProj
{
    public interface IHttpHeaderEvaluator
    {
        string HeaderName { get; }
        string ErrorCode { get; }
        bool Evaluate(NameValueCollection headers);
    }

    /// TODO: Clase 5 - Actividad 1: Unificar las clases de evaluacion, para usar el mismo metodo base evaluate
    /// a menos que la clase sea diferente.
    /// Tip: Abstract Class.
    /// TODO: Clase 5 - Actividad 2: 
    /// Generar un tipo propio de Error
    /// Y controlar su excepcion,  y la excepcion general cuando se ejecute el programa.
    public class AcceptEvaluator : IHttpHeaderEvaluator
    {
        public string HeaderName { get => "Accept"; }
        public string ErrorCode { get => "001"; }

        public bool Evaluate(NameValueCollection headers)
        {
            bool noContains = true;
            foreach (var header in headers)
            {
                if (header.ToString() == "Accept")
                {
                    return noContains;
                }
            }
            throw new Exception($"{ErrorCode} - {HeaderName}");
        }
    }

    public class StudentEvaluator : IHttpHeaderEvaluator
    {
        public string HeaderName { get => "StudentId"; }
        public string ErrorCode { get => "002"; }

        public bool Evaluate(NameValueCollection headers)
        {
            bool noContains = true;
            foreach (var header in headers)
            {
                if (header.ToString() == HeaderName)
                {
                    return noContains;
                }
            }
            throw new Exception($"{ErrorCode} - {HeaderName}");
        }
    }

    public class AcceptDatetimeEvaluator : IHttpHeaderEvaluator
    {
        public string HeaderName { get => "Accept-Datetime"; }
        public string ErrorCode { get => "003"; }

        public bool Evaluate(NameValueCollection headers)
        {
            bool noContains = true;
            foreach (var header in headers)
            {
                if (header.ToString() == HeaderName)
                {
                    return noContains;
                }
            }
            throw new Exception($"{ErrorCode} - {HeaderName}");
        }
    }
}
