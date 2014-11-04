using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var mco = new MatrixChainOrder();
            mco.Solve(new[] { 10,20,50,1,10 });
            
            Console.ReadLine();

        }

        
    }

    public class MatrixChainOrder
    {
        public List<int> kOrder = new List<int>();
        public void Solve(int[] sizes)
        {
            kOrder = new List<int>();

            int n = sizes.Length; 
            var M = new int[n,n];
            var K = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                M[i, i] = 0;
            }

            for (int matrixGroup = 2; matrixGroup < n; matrixGroup++)
            {
                for (int from = 1; from < n-matrixGroup+1; from++)
                {
                    int to = from + matrixGroup - 1;
                    M[from, to] = int.MaxValue;

                    for (int k = from; k < to; k++)
                    {
                        var cost = M[from,k] + M[k+1,to] + (sizes[from-1] * sizes[k] * sizes[to]);
                        if (M[from, to] > cost)
                        {
                            M[from, to] = cost;
                            K[from, to] = k;
                        }
                    }

                }
            }
            PrintMatrixOrder(K, 1, n-1);
        }
        public void PrintMatrixOrder(int[,] K, int from, int to)
        {
            if (from == to)
               Console.Write("A{0}", from);
             
            else
            {
                Console.Write(" (");
                PrintMatrixOrder(K, from, K[from, to]);
                PrintMatrixOrder(K, K[from, to] + 1, to);
                Console.Write(") ");
            }

        }

    }
}
