using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }
        
        
        public bool IsOpen(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < _size && j < _size)
           // if (i < 0 || i >= _size || j < 0 || j >= _size)
            //    throw new ArgumentOutOfRangeException();
            { return _open[i, j] = true; }
            /*     for (int z = 0; z < _size; z++)
                   {
                       for (int k = 0; k < _size; k++)
                       {
                           if (_open[i, j] == true)
                           { return true; }
                           else
                           { return false; }
                       }
                   }
            */
               return false;
        }
        private bool IsFull(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < _size && j < _size)
            //(i < 0  i >= _size || j < 0 || j >= _size || !_open[i, j])
            {
                return _full[i, j] = true;
            }
         
            
               return false ;
            

           // return IsFull(i - 1, j) || IsFull(i + 1, j) || IsFull(i, j - 1) || IsFull(i, j + 1);

          /*  for (int z = 0; z < _size; z++)
            {
                for (int k = 0; k < _size; k++)
                {
                    if (_full[i, j] == true)
                    { return true; }
                    else
                    { return false; }
                }

            }
          */
          //  return false;
        }

              public bool Percolate()
              {
                for (int j = 0; j < _size; j++)
                 {
                    if (IsFull(_size - 1, j))
                    return true;
                 }
                  return false;
              }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            // if (i < 0 || i >= _size || j < 0 || j >= _size || !IsOpen(i, j) || IsFull(i, j))
            //   return null;


            if (IsOpen(i + 1, j) && IsFull(i, j))
            {
                _full[i + 1, j] = true;
            }
            if (IsOpen(i, j + 1) && IsFull(i, j))
            {
                _full[i, j + 1] = true;
            }
            if (IsOpen(i - 1, j) && IsFull(i, j))
            {
                _full[i - 1, j] = true;
            }
            if (IsOpen(i, j - 1) && IsFull(i, j))
            {
                _full[i, j - 1] = true;
            }
            return null;
        }
        public void Open(int i, int j)
        {

            if (i >= 0 && j >= 0 && i < _size && j < _size)
            {
                _open[i, j] = true;
            }
            if (i == 0)
            {
              _full[i, j] = true;
            }
            else if (IsFull(i - 1, j))
            {
              _full[i, j] = true;
            }
             CloseNeighbors(i, j);

             //   if (i >= 0 && j >= 0 && i < _size && j < _size)
              //      {
             //      _open[i, j] = true;
             //      }

        }

    }
}
