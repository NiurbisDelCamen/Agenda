using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tarea5.BLL;
using Tarea5.Entidades;

namespace Tarea5.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cEventos.xaml
    /// </summary>
    public partial class cEventos : Window
    {
        public cEventos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Eventos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = EventosBLL.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = EventosBLL.GetList(p => p.Id == id);
                        break;
                    case 2://Descripcion
                        listado = EventosBLL.GetList(p => p.Descripcion.Contains(CriterioTextBox.Text));
                        break;
                }

            }
            else
            {
                listado = EventosBLL.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;
        }
    }
}
