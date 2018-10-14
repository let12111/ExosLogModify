using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Startup.VewModel;
namespace Startup
{
    /// <summary>
    /// Логика взаимодействия для UniversalEditWindow.xaml
    /// </summary>
    public partial class UniversalEditWindow : Window
    {
        public UniversalEditWindow()
        {
            InitializeComponent();
            this.DataContext = new UniversalWindowVM();
        }
    }
}
