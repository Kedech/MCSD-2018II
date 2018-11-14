using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WebServerProj
{
    public class FileManager
    {
        private string _basePath;

        public FileManager(string basePath)
        {
            _basePath = basePath;
        }

        // Recuperar todos los archivos de una carpeta
        public List<string> GetAllFiles()
        {
            var fileData = new List<string>();
            // TODO: Actividad: Filtrar archivos y carpetas
            foreach (var file in Directory.GetFiles(_basePath))
            {
                fileData.Add(Path.GetFileName(file));
            }
            return fileData;
            // return Directory.GetFileSystemEntries(_basePath).ToList();
        }

        // Recuperar 1 archivo por su nombre
        public byte[] GetFileByName(string fileName)
        {
            byte[] buffer;
            using (FileStream fs = File.Open(_basePath + fileName, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    fs.Position = 0;
                    int fileLength = (int)fs.Length;  // leer el tamanio del archivo
                    buffer = new byte[fileLength];    // Crear un contenedor de ese tamanio
                    int count;                        // El byte que se esta leyendo del archivo
                    int sum = 0;                      // El numero total de bytes leidos

                    // Lectura de cada elemento del archivo hasta que termina.
                    // Cuando termina termina el metodo read de un archivo devuelve 0
                    while ((count = fs.Read(buffer, sum, fileLength - sum)) > 0)
                    {
                        sum += count;
                    }
                }
                catch
                {
                    throw;
                }
            }

            return buffer;
        }
    }
}