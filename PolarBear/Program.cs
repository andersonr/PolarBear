using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PolarBear
{
    class Program
    {
        static char zero = '​';
        static char one = '‍';
        

        [STAThread]
        static void Main(string[] args)
        {

            //System.Windows.Forms.Clipboard.SetText($"{zero}{one}{z_zero}{z_one}{w_zero}{w_one}");

            Console.WriteLine("Digite o texto a ser codificado: ");
            var input = Console.ReadLine();

            var codify = new Snow();
            var textoInserido = codify.Encode(input);

            System.Windows.Forms.Clipboard.SetText(textoInserido);

            Console.WriteLine();
            Console.WriteLine("Texto copiado para area de transferencia");
            Console.WriteLine();
            Console.WriteLine("Texto decodificado: " + codify.Decode(textoInserido));

            Console.ReadKey();
        }
    }    
}
