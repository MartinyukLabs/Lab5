using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class MatrixMultiplicationMultithreading
    {
        private int[,] matrix1;
        private int[,] matrix2;
        private int[,] resultMatrix;
        private Semaphore semaphore;

        public MatrixMultiplicationMultithreading(int[,] matrix1, int[,] matrix2)
        {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
            this.resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            this.semaphore = new Semaphore(2, 2);
        }

        public void Multiply()
        {
            int numThreads = 4;
            Thread[] threads = new Thread[numThreads];

            for (int i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(() => MultiplyThread(i));
                threads[i].Start();
            }

            for (int i = 0; i < numThreads; i++)
                threads[i].Join();

            Console.WriteLine("Multiplication result:");
            PrintMatrix(resultMatrix);
        }

        private void MultiplyThread(int threadId)
        {
            int numRows = matrix1.GetLength(0);
            int numCols = matrix2.GetLength(1);
            int numIterations = numRows * numCols / 4;
            int startIteration = threadId * numIterations;
            int endIteration = (threadId + 1) * numIterations;

            for (int iteration = startIteration; iteration < endIteration; iteration++)
            {
                int row = iteration / numCols;
                int col = iteration % numCols;
                int sum = 0;

                for (int i = 0; i < matrix1.GetLength(1); i++)
                {
                    try
                    {
                        sum += matrix1[row, i] * matrix2[i, col];
                    }
                    catch { }
                }

                lock (resultMatrix)
                {
                    semaphore.WaitOne();
                    try
                    {
                        resultMatrix[row, col] = sum;
                    }
                    catch { }
                    semaphore.Release();
                }
            }
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
        }
    }
}
