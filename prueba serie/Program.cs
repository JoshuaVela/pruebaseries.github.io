using System;

namespace Trabajo
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] num_random = Generador_ConMix(4, 5, 7, 8);
            // promedio(num_random);
            if (promedio(num_random) && series(num_random) && poker(num_random))
            {
                Console.WriteLine("No se rechaza la hipsotesis");
            }
            else
            {
                Console.WriteLine("Se rechaza la hipotesis");
            }
            // SET != lista entonces habia repetidos
            // la serie es completa si no hay numeros repetidos
            // for lista numeros primos a,c, m=1001, X_0= nuemro de la suerte
            // las series que pasasn las guardan en archivo.
            for (int i = 0; i < num_random.Length; i++)
            {
                Console.WriteLine(num_random[i]);
            }
        }
        public static double[] Generador_ConMix(int x0, int a, int c, int mod)
        {
            int Xn;
            int Xsig = 0;
            Xn = x0;
            double[] num_random = new double[mod];
            //mod porcentaje division que da el residuo 
            for (int i = 0; i < mod; i++)
            {
                Xsig = ((a * Xn) + c) % (mod);
                // Console.WriteLine(Xsig);
                Xn = Xsig;
                num_random[i] = (Xsig * 1.0) / mod;
            }
            return num_random;
        }

        // 1,2,3,4

        static bool promedio(double[] num_random)
        {
            double formula;
            double promedio;
            double suma = 0;
            for (int i = 0; i < num_random.Length; i++)
            {
                suma = num_random[i] + suma;
            }
            promedio = suma / num_random.Length;
            formula = Math.Abs(((0.5 - Math.Abs(promedio)) * 4.4721) / 0.28867513);
            // Console.WriteLine(formula);
            // Console.WriteLine(promedio);
            if (formula < 1.96)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static Boolean series(double[] num_random)
        {
            double formulac1;
            double formulac2;
            double formulac3;
            double formulac4;
            double formut;
            double fe = 0;
            double valor1 = 0, valor2 = 0;
            int foc1 = 0, foc2 = 0, foc3 = 0, foc4 = 0;
            for (int i = 0; i < num_random.Length - 1; i++)
            {
                valor1 = num_random[i];
                valor2 = num_random[i + 1];
                if (valor1 < 0.5 && valor2 < 0.5)
                {
                    foc1++;
                }
                else if (valor1 > 0.5 && valor2 < 0.5)
                {
                    foc2++;
                }
                else if (valor1 < 0.5 && valor2 > 0.5)
                {
                    foc3++;
                }
                else if (valor1 > 0.5 && valor2 > 0.5)
                {
                    foc4++;
                }
            }
            fe = Math.Abs(((num_random.Length - 1)/4));
            formulac1 = Math.Pow(foc1 - fe,2);
            formulac2 = Math.Pow(foc2 - fe,2);
            formulac3 = Math.Pow(foc3 - fe,2);
            formulac4 = Math.Pow(foc4 - fe,2);
            formut = ((formulac1 + formulac2 + formulac3 + formulac4)*4)/(num_random.Length - 1);
            if (formut < 7.81)
            {
                return true;
            }
            else
            {
                return false;
            }         
        }

        static bool poker(double[] num_random)
        {
            double formula;
            double promedio;
            double suma = 0;
            for (int i = 0; i < num_random.Length; i++)
            {
                suma = num_random[i] + suma;
            }
            promedio = suma / num_random.Length;
            formula = Math.Abs(((0.5 - Math.Abs(promedio)) * 4.4721) / 0.28867513);
            // Console.WriteLine(formula);
            // Console.WriteLine(promedio);
            if (formula < 1.96)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
