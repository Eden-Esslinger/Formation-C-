﻿using Serie_I;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serie_d_exercices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElementaryOperations.BasicOperation(2, 3, 'L');
            ElementaryOperations.BasicOperation(2, 3, '/');
            ElementaryOperations.BasicOperation(2, 0, '/');
            ElementaryOperations.BasicOperation(2, 0, '*');
            ElementaryOperations.BasicOperation(2, 5, '*');
            ElementaryOperations.IntegerDivision(2, 5);
            ElementaryOperations.IntegerDivision(20, 5);
            ElementaryOperations.IntegerDivision(2, 0);
            ElementaryOperations.Pow(2, 3);
            ElementaryOperations.Pow(2, -3);
            ElementaryOperations.Pow(2, 0);
            Console.ReadKey();
        }
    }
}
namespace Serie_I
{
    public static class ElementaryOperations
    {

        public static void BasicOperation(int a, int b, char operation)
        {
            int c;
            if (b == 0 && operation == '/')
            { Console.WriteLine($"{a} {operation} {b} = Operation invalide."); }
            // else if (operation != '+' || '-' || '*' || '/')
            // { Console.WriteLine(a + operation + b + "= Operation invalide."); }
            else
            {
                switch (operation)
                {
                    case '+':
                        c = a + b;
                        Console.WriteLine($"{a} {operation} {b} = {c}");
                        break;
                    case '-':
                        c = a - b;
                        Console.WriteLine($"{a} {operation} {b} = {c}");
                        break;
                    case '*':
                        c = a * b;
                        Console.WriteLine($"{a} {operation} {b} = {c}");
                        break;
                    case '/':
                        c = a / b;
                        Console.WriteLine($"{a} {operation} {b} = {c}");
                        break;
                    default:
                        Console.WriteLine($"{a} {operation} {b} = Operation invalide.");
                        break;

                }
            }
        }
        
        public static void IntegerDivision(int a, int b)
        {
            switch (b)
            {
                case 0:
                    Console.WriteLine($"{a} : {b} = Operation invalide.");
                    break;
                default:
                    int q = a / b;
                    int r = a % b;

                    if (r == 0)
                    { Console.WriteLine($"{a} = {q} * {b}"); }
                    else
                    { Console.WriteLine($"{a} = {q} * {b} + {r}"); }
                    break;
            }

        }

            public static void Pow(int a, int b)
            {
            int produit = a;
            if (b < 0)
            { Console.WriteLine($"{a} ^ {b} = Operation invalide."); }
            else if (b == 0)
            { Console.WriteLine($"{a} ^ {b} = 1"); }
            else
            { for (int n = 1; n < b; n++)
                {
                    produit *= a;
                }
                Console.WriteLine($"{a} ^ {b} = {produit}");
            }
            } 

        
    }
}
