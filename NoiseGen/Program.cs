using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FreeImageAPI;

namespace NoiseGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var colors = new List<RGBQUAD>();
            foreach (int i in Enumerable.Range(0, 255))
            {
                colors.Add(new RGBQUAD(Color.FromArgb(i, i, i)));
            }

            var resolution = 1024;
            try
            {
                if (args[0] != null) resolution = int.Parse(args[0]);
            } catch
            {
                Console.WriteLine("Couldn't parse resolution number from input.");
            }

            var bitmap = FreeImage.Allocate(resolution, resolution, 24);
            var rand = new Random();
            
            foreach (uint y in Enumerable.Range(0, resolution))
            {
                foreach (uint x in Enumerable.Range(0, resolution))
                {
                    var randomValue = rand.Next(0, 255);
                    var color = colors[randomValue];
                    FreeImage.SetPixelColor(bitmap, x, y, ref color);
                }
            }
            
            FreeImage.Save(FREE_IMAGE_FORMAT.FIF_PNG, bitmap, "output.png", 0);
        }
    }
}
