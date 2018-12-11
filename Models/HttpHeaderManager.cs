using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace WebServerProj
{
    ///
    /// Analizar Headers de HTTP
    /// Retornar errores, si los headers no estan completos
    /// En base a diferentes codigos de error.
    ///
    public static class HttpHeaderManager
    {
        // Accept
        // Accept-Encoding
        // Accept-Language
        // Accept-Datetime
        // Host
        // User-Agent
        // StudentId

        ///
        /// return true, si no hay problema
        /// retorna codigos de error del 001 al 010 con una descripcion.
        public static bool ValidateHeaders(NameValueCollection headers)
        {
            var result = false;
            foreach (object header in headers)
            {
                result = ValidateHeaderName(header.ToString());
            }
            return result;
        }
        
        public static bool ValidateHeaderName(string headerName)
        {
            switch (headerName)
            {
                case "Accept":
                    break;
                case "Accept-Encoding":
                    break;
                case "Accept-Language":
                    break;
                case "Accept-Datetime":
                    break;
                case "Host":
                    break;
                case "User-Agent":
                    break;
                case "Student-Id":
                    break;
                default:
                    throw new Exception("000-Hay un problema general");
            }
            return true;
        }
    }
}