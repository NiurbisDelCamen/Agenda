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
    /// Interaction logic for cContactos.xaml
    /// </summary>
    public partial class cContactos : Window
    {
        public cContactos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Contactos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = ContactosBLL.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = ContactosBLL.GetList(p => p.Id == id);
                        break;
                    case 2://Nombre
                        listado = ContactosBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Apellidos
                        listado = ContactosBLL.GetList(p => p.Apellidos.Contains(CriterioTextBox.Text));
                        break;
                    case 4://Direccion
                        listado = ContactosBLL.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));
                        break;
                }
                

            }
            else
            {
                listado = ContactosBLL.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;


        }
    }
}
