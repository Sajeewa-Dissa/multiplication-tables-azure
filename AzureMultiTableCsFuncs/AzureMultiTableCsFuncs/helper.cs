using System;

namespace AzureMultiTablesCsFuncs
{
    public class helper
    {
        public string createCoords(int x0, int y0, int radius, int modulus)
        {
            string coords = string.Empty;
            for (int i = 0; i < modulus; i++)
            {
                decimal x = (decimal)Math.Abs(x0 + radius * Math.Cos(2 * Math.PI * i / modulus) - 2 * x0);  //returns x coord
                decimal y = (decimal)Math.Abs(y0 + radius * Math.Sin(2 * Math.PI * i / modulus) - 2 * y0);  //returns y coord
                coords += addSquareBrackets(decimal.Round(x, 2).ToString() + "," + decimal.Round(y, 2).ToString()) + ",";
            }
            //add an outer set of square brackets to final result returned. Also remove final comma.
            return addSquareBrackets(trimFinalCharIfComma(coords));
        }

        public string createMatrix(int multiple, int modulus)
        {
            string matrix = string.Empty;
            for (int i = 0; i < modulus; i++)
            {
                int result = (i * multiple) % modulus;
                matrix += addSquareBrackets(i.ToString() + "," + result.ToString()) + ",";
            }
            //add an outer set of square brackets to final result returned. Also remove final comma.
            return addSquareBrackets(trimFinalCharIfComma(matrix));
        }

        public string addSquareBrackets(string input)
        {
            return "[" + input + "]";
        }

        public string trimFinalCharIfComma(string input)
        {
            int index = input.LastIndexOf(",");
            if (index == input.Length - 1)
            {
                return input.Substring(0, input.Length - 1);
            }
            else
            {
                return input;
            }
        }
    }
}
