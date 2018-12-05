using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WebServerProj.Models
{
    public class TestReflectionClass
    {
        public int TestField;
        public string ReadProperty {get;set;}
        public string SetProperty {get;set;}

        public void MethodTest(){
            Console.WriteLine();
        }
    }
}