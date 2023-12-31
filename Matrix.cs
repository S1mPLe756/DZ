﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR
{
    internal class Matrix
    {
        private int rows;
        private int columns;
        private int[,] matrix;

        public int Rows
        {
            get { return rows; }
        }

        public int Columns
        {
            get { return columns; }
        }

        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            private set { matrix[i, j] = value; }
        }

        public Matrix(int r, int c)
        {
            rows = r;
            columns = c;
            matrix = new int[rows, columns];
        }

        public Matrix(string filename)
        {
            using StreamReader streamReader = new StreamReader(filename);
            var rc = streamReader.ReadLine().Split(' ');
            rows = Convert.ToInt32(rc[0]);
            columns = Convert.ToInt32(rc[1]);
            matrix = new int[rows, columns];
            var m = streamReader.ReadToEnd().Split('\n');
            var c = 0;
            for (int i = 0; i < rows; i++)
            {
                var line = m[i].Split(' ');
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = Convert.ToInt32(line[j]);
                }
            }
        }


        public Matrix Shift(Matrix m)
        {
            var res = new Matrix(rows, columns);
            for (int j = 0; j < rows; j++)
            {
                for (int i = 1; i < columns; i++)
                {
                    res[j, i] = m[j, i - 1];
                }
                res[j, 0] = m[j, columns - 1];
            }
            return res;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    sb.Append($"{matrix[i, j],2}");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
