using POO_TP3_Ejercicio1.Entidades;
using System;

namespace POO_TP3_Ejercicio1.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresá la coordenada x del punto inicial");     // Ingreso de los valores x e y para el punto inicial y final
            double valorXInicial = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingresá la coordenada y del punto inicial");
            double valorYInicial = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingresá la coordenada x del punto final");
            double valorXFinal = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingresá la coordenada y del punto final");
            double valorYFinal = double.Parse(Console.ReadLine());

            SegmentoDeRecta segmento = new SegmentoDeRecta(valorXInicial, valorXFinal, valorYInicial, valorYFinal);     // Creación del objeto segmento

            Console.WriteLine($"El módulo del segmento es: {segmento.GetModuloDelSegmento()}");

            
            if (segmento.GetEsRecto())     // Emite mensajes según sea recto u oblicuo
            {
                Console.WriteLine($"El segmento es recto.");
            }
            else
            {
                Console.WriteLine($"El segmento es oblicuo.");
            }

            segmento.GetPuntoMedio();       // Muestra el punto medio

            Console.ReadLine();
        }
    }
}
