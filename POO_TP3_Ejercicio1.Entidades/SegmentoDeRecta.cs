using System;

namespace POO_TP3_Ejercicio1.Entidades
{
    public class SegmentoDeRecta
    {
        private double inicioX;      // Atributos privados
        private double inicioY;
        private double finalX;
        private double finalY;

        public SegmentoDeRecta(double xInicial, double xFinal, double yInicial, double yFinal)
        {
            inicioX = xInicial;
            finalX = xFinal;
            inicioY = yInicial;
            finalY = yFinal;
        }
        public bool Validar()
        {
            return !(inicioX == finalX && inicioY == finalY);
        }
        public void SetInicioX(double valor)        // Propiedades
        {
            inicioX = valor;
        }
        public double GetInicioX() => inicioX;
        public double GetInicioY() => inicioY;
        public double GetFinalX() => finalX;
        public double GetFinalY() => finalY;
        public void SetInicioY(double valor)
        {
            inicioY = valor;
        }

        public void SetFinalX(double valor)
        {
            finalX = valor;
        }

        public void SetFinalY(double valor)
        {
            finalY = valor;
        }
        public string GetPuntoDeInicio()     // Métodos
        {
            return $"El punto de inicio tiene coordenadas {inicioX} , {inicioY}";
        }

        public string GetPuntoFinal()
        {
            return $"El punto final tiene coordenadas {finalX} , {finalY}";
        }

        public string GetPuntoMedio()
        {

            return $"El punto medio es {finalX - inicioX} , {finalY - inicioY}";
        }

        public double GetModuloDelSegmento()

        {
            return Math.Sqrt(
                            Math.Pow((finalX - inicioX), 2)
                            +
                            Math.Pow((finalY - inicioY), 2)
                            );
        }

        public bool GetEsRecto()
        {
            return inicioX == finalX || inicioY == finalY;
        }

        public string GetSegmento()
        {
            return $"({inicioX} , {inicioY}) ,( {finalX} , {finalY})";             
        }

    }
}

    

