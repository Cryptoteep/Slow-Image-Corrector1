using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class ImageFilter
    {
        private static void ClampColorComponent(ref int component)
        {
            if (component > 255) component = 255;
            if (component < 0) component = 0;
        }

        public static void ApplyBritness(ref int r, ref int g, ref int b, int birtness)
        {
            r = r + birtness;
            g = g + birtness;
            b = b + birtness;

            ClampColorComponent(ref r);
            ClampColorComponent(ref g);
            ClampColorComponent(ref b);
        }

        public static void ApplyContrast(ref int r, ref int g, ref int b, float contrast)
        {
            float rd = (Math.Abs(127 - r) * contrast) / 100;
            float gd = (Math.Abs(127 - g) * contrast) / 100;
            float bd = (Math.Abs(127 - b) * contrast) / 100;

            if (r > 127) r += (int) rd; else r -= (int) rd;
            if (g > 127) g += (int) gd; else g -= (int) gd;
            if (b > 127) b += (int) bd; else b -= (int) bd;

            ClampColorComponent(ref r);
            ClampColorComponent(ref g);
            ClampColorComponent(ref b);
        }

        public static void ClapmColor(ref int r, ref int g, ref int b)
        {
            ClampColorComponent(ref r);
            ClampColorComponent(ref g);
            ClampColorComponent(ref b);
        }


        public static void ApplyDiscolor(ref int r, ref int g, ref int b)
        {
            int c = (r + g + b) / 3;

            r = c;
            g = c;
            b = c;
        }
        /// <summary>
        /// ГОВНОСЕПИЯ
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public static void ApplySepia(ref int r, ref int g, ref int b)
        {
            float rf = (float)r;
            float gf = (float)g;
            float bf = (float)b;


            bf = (float) ((rf * 0.393f) + (gf * 0.769f) + (bf * 0.189f));
            gf = (float) ((rf * 0.349f) + (gf * 0.686f) + (bf * 0.168f));
            rf =  (float)((rf * 0.272f) + (gf * 0.534f) + (bf * 0.131f));

            r = (int)rf ;
            g = (int)gf ;
            b = (int)bf;

            ClampColorComponent(ref r);
            ClampColorComponent(ref g);
            ClampColorComponent(ref b);
        }
    }
}
