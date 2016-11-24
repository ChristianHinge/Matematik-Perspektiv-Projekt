using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows.Forms;


namespace Matematik_Perspektiv_Projekt
{
    static class Program
    {
        private static string dataDirectory;
        private static string Data;
        private static Vector View;
        private static FileStream fs;
        private static List<Vector> points = new List<Vector>();
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Hinge er konge");
            dataDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Data = dataDirectory + "//Punkter.txt";
            View = null;
            LoadVectors();

            //Tilføj alle points

            //Slut
            string s = "";
            foreach (Vector vect in points)
            {
                Console.WriteLine(get_z_intersection(View, vect).print());
                s += System.Environment.NewLine + get_z_intersection(View, vect).print();
                

            }
            Clipboard.SetText(s);
            Console.WriteLine("Kopieret til klipboard");
            Console.ReadLine();
        }
        private static Vector get_z_intersection(Vector origin, Vector vect)
        {
            Vector r = vect-origin;
            float x = vect.x + ((-vect.z / r.z) * r.x);
            float y = vect.y + ((-vect.z / r.z) * r.y);
            return new Vector(x, y, 0, vect.name);
        }
        private static void LoadVectors()
        {
            string vect_name;
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";


            if (!File.Exists(Data))
            {
                fs = File.Create(Data);
                fs.Close();
            }
            StreamReader sr = new StreamReader(Data);
            
            string line = sr.ReadLine();

            while (line != null)
            {
                if (line[0] == '*')
                {
                    line = sr.ReadLine();
                    continue;
                }
                vect_name = line.Split('=')[0];
                line = line.Split('(')[1];
                line = line.Split(')')[0];
                if (View == null)
                {
                    View = new Vector(float.Parse(line.Split(',')[0], NumberStyles.Any, ci),
                    float.Parse(line.Split(',')[1], NumberStyles.Any, ci),
                    float.Parse(line.Split(',')[2], NumberStyles.Any, ci), vect_name);
                    line = sr.ReadLine();
                    continue;
                }
                points.Add(new Vector(float.Parse(line.Split(',')[0], NumberStyles.Any, ci), 
                    float.Parse(line.Split(',')[1], NumberStyles.Any, ci), 
                    float.Parse(line.Split(',')[2], NumberStyles.Any, ci), vect_name));
                    line = sr.ReadLine();
            }
            sr.Close();
        }
    }
}
