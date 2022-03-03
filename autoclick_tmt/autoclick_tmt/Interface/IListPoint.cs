using autoclick.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace autoclick.Interface
{
    interface IListPoint
    {
        
        bool Add(Pointer p);
        int Find(Pointer p);
        Pointer FindX(int i);
        bool Edit(Pointer p);
        bool Remove(Pointer p);
        Pointer Get(int i);
        bool OpenFile();
        bool SaveToFile();
        string ToString();

    }
}
