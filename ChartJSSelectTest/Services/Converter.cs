using System;
using System.Drawing;
using System.IO;

namespace ChartJSSelectTest.Services
{
    public static class Converter
    {
        public static Bitmap Base64StringToBitmap(this string base64String)
        {
            Bitmap bmpReturn = null;

            var splitComma = base64String.Split(','); // delete header

            byte[] byteBuffer = Convert.FromBase64String(splitComma[1]);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();

            return bmpReturn;
        }
    }
}
