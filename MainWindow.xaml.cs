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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tarea5.UI.Consultas;
using Tarea5.UI.Registros;

namespace Tarea5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ContactoButton_Click(object sender, RoutedEventArgs e)
        {
            rContactos rp = new rContactos();
            rp.Show();
        }

        private void EventoButton_Click(object sender, RoutedEventArgs e)
        {
            rEventos rp = new rEventos();
            rp.Show();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            cContactos c = new cContactos();
            c.Show();
        }

        private void ConsultarEventosButton_Click(object sender, RoutedEventArgs e)
        {
            cEventos c = new cEventos();
            c.Show();
        }
    }
}
