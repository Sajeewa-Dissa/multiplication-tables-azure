using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public string simpleCall(int value)
	{
		return string.Format("You entered: {0}", value);
	}

    public string createCoords(int x0, int y0, int radius, int modulus)
    {
        string coords = string.Empty;
        for (int i = 0; i < modulus; i++)
        {
            decimal x = (decimal)Math.Abs(x0 + radius * Math.Cos(2 * Math.PI * i / modulus) - 2 * x0);  //returns x coord
            decimal y = (decimal)Math.Abs(y0 + radius * Math.Sin(2 * Math.PI * i / modulus) - 2 * y0);  //returns y coord
            coords += addSquareBrackets(decimal.Round(x, 2).ToString() + "," + decimal.Round(y, 2).ToString()) + ",";
        }
        //add an outer set of square brackets to final result returned.
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
        //add an outer set of square brackets to final result returned.
        return addSquareBrackets(trimFinalCharIfComma(matrix));
    }

    private string addSquareBrackets(string input)
    {
        return "[" + input + "]";
    }

    private string trimFinalCharIfComma(string input)
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
