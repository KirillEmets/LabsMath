using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Matrix
    {
        public int n;
        public int[,] values;

        public Matrix(int n)
        {
            this.n = n;
            values = new int[n, n];
        }

        public Matrix(int[,] m)
        {
            if (m.GetLength(0) != m.GetLength(1))
                throw new Exception("Matrix has to be square");

            values = m;
            n = values.GetLength(0);
        }

        public Matrix multipliedOn(Matrix m)
        {
            Matrix result = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int s = 0;
                    for (int k = 0; k < n; k++)
                    {
                        s += values[i, k] * m.values[k, j];
                    }
                    result.values[i, j] = s;
                }
            }

            return result;
        }

        public Matrix toPower(int p)
        {
            Matrix result = this;
            for (int i = 0; i < p - 1; i++)
            {
                result = result.multipliedOn(this);
            }
            return result;
        }

        public Matrix combinedWith(Matrix m)
        {
            Matrix result = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.values[i, j] = values[i, j] + m.values[i, j];
                }
            }

            return result;
        }

        public Matrix normilized
        {
            get
            {
                Matrix result = new Matrix(n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (values[i, j] >= 1) result.values[i, j] = 1;
                    }
                }

                return result;
            }
        }

        public Matrix getClosure()
        {
            Matrix result = this;
            for (int i = 2; i < n; i++)
            {
                result = result.combinedWith(toPower(i)).normilized;
            }
            result = result.combinedWith(I(n)).normilized;
            return result;
        }

        public Matrix transposed
        {
            get
            {
                Matrix res = new Matrix(n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        res.values[i, j] = values[j, i];
                    }
                }
                return res;
            }
        }

        public Matrix elementMultiply(Matrix m)
        {
            Matrix res = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res.values[i, j] = values[i, j] * m.values[i, j];
                }
            }
            return res;
        }

        public static Matrix I(int n)
        {
            Matrix res = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                res.values[i, i] = 1;
            }
            return res;
        } 
    }
}
