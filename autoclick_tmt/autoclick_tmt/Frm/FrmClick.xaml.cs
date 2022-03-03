using autoclick.Model;
using autoclick_tmt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace autoclick_tmt.Frm
{
    /// <summary>
    /// Interaction logic for FrmClick.xaml
    /// </summary>
    public partial class FrmClick : Window
    {
        ListPointer LClick = null;
        ListPointer LDrag = null;
        
        public FrmClick()
        {
            
            InitializeComponent();
            KeyboardHandler d = new KeyboardHandler(this);


        }

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
            //mouse_event(MOUSEEVENTF_LEFTUP, Xposition, Yposition, 0, 0);
            //var p = Mouse.GetPosition(Application.Current.MainWindow);
            //Console.WriteLine(p.ToString());
        }

        
        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            
        }

        private void txtX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
