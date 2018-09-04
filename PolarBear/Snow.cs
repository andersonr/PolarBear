using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PolarBear
{
    public class Snow
    {
        const char zero = '​';
        const char one = '‍';

        /// <summary>
        /// Encoding regular text do 0 width caracters
        /// </summary>
        /// <param name="text">Text to encoding</param>
        /// <returns>Text with just 0 width caracteres</returns>
        public string Encode(string text)
        {
            try
            {
                text = HttpUtility.UrlEncode(text);

                var buffer = System.Text.Encoding.ASCII.GetBytes(text);
                var sb = new StringBuilder();
                
                foreach (byte item in buffer)
                    sb.Append(Convert.ToString(item, 2).PadLeft(8, '0'));

                return sb.ToString().Replace('1', one).Replace('0', zero);
            }
            catch (Exception err)
            {
                throw new Exception($"Error on encoding: {err.ToString()}");
            }
        }

        /// <summary>
        /// Decode zero width caracteres into regular text
        /// </summary>
        /// <param name="text">Text to decode</param>
        /// <returns>Returns regular text</returns>
        public string Decode(string text)
        {
            var textBin = text.Replace(one, '1').Replace(zero, '0');

            var listaBytes = new List<byte>();
            for (int i = 0; i < textBin.Length; i += 8)
            {
                var faixaBytes = textBin.Substring(i, 8);
                listaBytes.Add(Convert.ToByte(faixaBytes, 2));
            }

            return Encoding.ASCII.GetString(listaBytes.ToArray());
        }
    }
}
