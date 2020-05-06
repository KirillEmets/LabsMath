using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Matrix
    {
        public int n;
        public double[,] values;
        public int[,] IntValues
        {
            get
            {
                int[,] res = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        res[i, j] = (int)Math.Floor(values[i, j]);
                    }
                }
                return res;
            }
            set
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        
                        values[i, j] = value[i, j];
                    }
                }
            }
        }

        public Matrix(int n)
        {
            this.n = n;
            values = new double[n, n];
        }

        public Matrix(int[,] m)
        {
            if (m.GetLength(0) != m.GetLength(1))
                throw new Exception("Matrix has to be square");

            IntValues = m;
            n = values.GetLength(0);
        }

        public Matrix(double[,] m)
        {
            if (m.GetLength(0) != m.GetLength(1))
                throw new Exception("Matrix has to be square");

            values = m;
            n = values.GetLength(0);
        }

        public Matrix MultipliedOn(Matrix m)
        {
            Matrix result = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double s = 0;
                    for (int k = 0; k < n; k++)
                    {
                        s += values[i, k] * m.values[k, j];
                    }
                    result.values[i, j] = s;
                }
            }

            return result;
        }

        public Matrix ToPower(int p)
        {
            Matrix result = this;
            for (int i = 0; i < p - 1; i++)
            {
                result = result.MultipliedOn(this);
            }
            return result;
        }

        public Matrix CombinedWith(Matrix m)
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

        public Matrix Normilized
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

        public Matrix GetClosure()
        {
            Matrix result = this;
            for (int i = 2; i < n; i++)
            {
                result = result.CombinedWith(ToPower(i)).Normilized;
            }
            result = result.CombinedWith(I(n)).Normilized;
            return result;
        }

        public Matrix Transposed
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

        public Matrix ElementMultiply(Matrix m)
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

        public Matrix ElementMultiply(double m)
        {
            Matrix res = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res.values[i, j] = values[i, j] * m;
                }
            }
            return res;
        }

        public Matrix Floor
        {
            get
            {
                Matrix res = new Matrix(n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        res.values[i, j] = (int)Math.Floor(values[i, j]);
                    }
                }
                return res;
            }
        }

        public Matrix Round
        {
            get
            {
                Matrix res = new Matrix(n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        res.values[i, j] = (int)Math.Round(values[i, j]);
                    }
                }
                return res;
            }
        }

        public Matrix ToOnes()
        {
            Matrix res = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (values[i, j] > 0) res.values[i, j] = 1;
                }
            }
            return res;
        }

        public Matrix And(Matrix m)
        {
            Matrix res = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (values[i, j] != 0 && m.values[i, j] != 0)
                        res.values[i, j] = 1;
                }
            }
            return res;
        }

        public Matrix Or(Matrix m)
        {
            Matrix res = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (values[i, j] != 0 || m.values[i, j] != 0)
                        res.values[i, j] = 1;
                }
            }
            return res;
        }

        public Matrix Not
        {
            get
            {
                Matrix res = new Matrix(n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (values[i, j] == 0) res.values[i, j] = 1;
                    }
                }
                return res;
            }
        }

        public static Matrix Tril(int n)
        {
            Matrix res = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < j) res.values[i, j] = 1;
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
