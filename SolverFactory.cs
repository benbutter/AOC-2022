﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC_2022
{
    public class SolverFactory
    {
        public ISolver GetSolver(string suffix)
        {
            Type type = GetSolverType(suffix);

            ISolver solver = CreateSolverInstance(type);

            solver.SetInput(GetInput(suffix));

            return solver;

        }

        private static Type GetSolverType(string suffix)
        {
            string typename = $"AOC_2022._{suffix}.Solver{suffix}";

            Type type = Type.GetType(typename);

            if (type == null)
            {
                throw new Exception("Type not found.");
            }

            return type;
        }

        private static ISolver CreateSolverInstance(Type type)
        {
            var instance = Activator.CreateInstance(type);

            ISolver solver = (ISolver)instance;
            return solver;
        }

        private StreamReader GetInput(string suffix)
        {

            string path = $"C:\\Users\\benbu\\source\\repos\\AOC-2022\\{suffix}\\input.txt";
            if (!File.Exists(path))
            {
                throw new Exception("File not found.");
            }

            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            var streamReader = new StreamReader(fileStream, Encoding.UTF8);

            return streamReader;
        }
    }
}
