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

namespace Tarea5.UI.Registros
{
    /// <summary>
    /// Interaction logic for rEventos.xaml
    /// </summary>
    public partial class rEventos : Window
    {
        public rEventos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            FechaDatePicker.Text = Convert.ToString(DateTime.Now);
        }

        private  Eventos LlenaClase()
        {
            Eventos eventos = new Eventos();
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                IdTextBox.Text = "0";
            }
            else eventos.Id = Convert.ToInt32(IdTextBox.Text);
            eventos.Descripcion = DescripcionTextBox.Text;
            eventos.Fecha = Convert.ToDateTime(FechaDatePicker.SelectedDate);

            return eventos;
        }

        private void LlenaCmpos(Eventos eventos)
        {
            IdTextBox.Text = Convert.ToString(eventos.Id);
           DescripcionTextBox.Text = eventos.Descripcion;
            FechaDatePicker.SelectedDate = eventos.Fecha;
        }

        private bool ExisteBDatos()
        {
            Eventos eventos = EventosBLL.Buscar(Convert.ToInt32(IdTextBox.Text));

            return (eventos != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                System.Windows.MessageBox.Show(DescripcionTextBox.Text, "No puede estar vacio");
                DescripcionTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Eventos eventos;
            bool paso = false;

            if (!Validar())
                return;
            eventos = LlenaClase();

            if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                paso = EventosBLL.Guardar(eventos);

            else
            {
                if (!ExisteBDatos())
                {
                    System.Windows.MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = EventosBLL.Modificar(eventos);
            }

            if (paso)
            {
                Limpiar();
                System.Windows.MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(IdTextBox.Text);

            Limpiar();

            if (EventosBLL.Eliminar(id))
                System.Windows.MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                System.Windows.MessageBox.Show(IdTextBox.Text, "No se puede eliminar una contacto que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Eventos eventos = new Eventos();
            int.TryParse(IdTextBox.Text, out id);

            Limpiar();

            eventos = EventosBLL.Buscar(id);

            if (eventos != null)
            {
                System.Windows.MessageBox.Show("Evento Encontrado");
                LlenaCmpos(eventos);
            }
            else
            {
                System.Windows.MessageBox.Show("Evento no Encontrado");
            }
        }
    }
}
