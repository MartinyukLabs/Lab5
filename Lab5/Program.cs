using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            //////////////////1
            //ProducerConsumer pc = new ProducerConsumer();
            //pc.Start();

            /////////////////2
            //TrafficLightManager trafficLightManager = new TrafficLightManager();
            //trafficLightManager.Start();

            ////////////////3
            //QuickSortMultithreading quickSort = new QuickSortMultithreading();
            //quickSort.Start();

            ///////////////4
            int[,] matrix1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] matrix2 = new int[,] { { 7, 8 }, { 9, 10 }, { 11, 12 } };

            MatrixMultiplicationMultithreading matrixMult = new MatrixMultiplicationMultithreading(matrix1, matrix2);
            matrixMult.Multiply();

            Console.ReadKey();
        }
    }
}