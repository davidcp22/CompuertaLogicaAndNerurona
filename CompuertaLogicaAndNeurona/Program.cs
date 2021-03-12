using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuertaLogicaAndNeurona
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generamos pesos aleatorios
            Random valoresPesos = new Random();

            //Declaracion de varibles
            int[,] entradas = { { 1, 1 }, { 1, 0 }, { 0, 1 }, { 0, 0 }};
            int[] salidas = { 1, 0, 0, 0 };

            double p0 = valoresPesos.NextDouble();
            double p1 = valoresPesos.NextDouble();
            double u = valoresPesos.NextDouble();

            bool proceso = true;
            int iteracion = 0;
            
            //proceso donde la neurona aprende 
            while (proceso)
            {
                iteracion++;
                proceso = false;

                for (int i = 0; i <=3 ; i++)
                {
                    double funcionAgreacion = entradas[i, 0] * p0 + entradas[i, 1] * p1 + 1*u;

                    int salida;
                    if (funcionAgreacion > 0.7)
                        salida = 1;
                    else
                        salida = 0;


                    if (salida != salidas[i]) 
                    {
                        p0 = valoresPesos.NextDouble();
                        p1 = valoresPesos.NextDouble();
                        u = valoresPesos.NextDouble();
                        proceso = true;
                    }

                }

            }


            //For con funcion de agregacion
            for (int i = 0; i <= 3; i++)
            {
                double funcionAgreacion = entradas[i, 0] * p0 + entradas[i, 1] * p1 + 1 * u;

                int salida;
                if (funcionAgreacion > 0.7)
                    salida = 1;
                else
                    salida = 0;
                Console.WriteLine("Entradas: " + entradas[i, 0].ToString() + " y " + entradas[i, 1].ToString() + " = " +
                salidas[i].ToString() + " perceptron: " + salida.ToString());
            }

            //Imprime los pesos encontrados y las iteracioes requeridas
            Console.WriteLine("Pesos encontrados P0= " + p0.ToString() + " P1= " + p1.ToString() + " U= " + u.ToString());
            Console.WriteLine("Iteraciones requeridas: " + iteracion.ToString());
            Console.ReadKey();




        }
    }
}
