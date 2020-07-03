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
    /// Interaction logic for rContactos.xaml
    /// </summary>
    public partial class rContactos : Window
    {
        public rContactos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            TelefonosTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            CorreoTextBox.Text = string.Empty;
        }


        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Contactos LlenaClase()
        {
            Contactos contactos = new Contactos();
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                IdTextBox.Text = "0";
            }
            else contactos.Id = Convert.ToInt32(IdTextBox.Text);
            contactos.Nombre = NombreTextBox.Text;
            contactos.Telefonos = TelefonosTextBox.Text;
            contactos.Direccion = DireccionTextBox.Text;
            contactos.Apellidos = ApellidosTextBox.Text;
            contactos.Correo = CorreoTextBox.Text;

            return contactos;
        }

        private void LlenaCampos(Contactos contactos)
        {
            IdTextBox.Text = Convert.ToString(contactos.Id);
            NombreTextBox.Text = contactos.Nombre;
            ApellidosTextBox.Text = contactos.Apellidos;
            DireccionTextBox.Text = contactos.Direccion;
            TelefonosTextBox.Text = contactos.Telefonos;
            CorreoTextBox.Text = contactos.Correo;
        }

        private bool ExisteBD()
        {
            Contactos contactos = ContactosBLL.Buscar(Convert.ToInt32(IdTextBox.Text));

            return (contactos != null);
        }

        private bool Validar()
        {
            bool paso = true;


            if (NombreTextBox.Text == string.Empty)
            {
                System.Windows.MessageBox.Show(NombreTextBox.Text, "No puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            if(ApellidosTextBox.Text == string.Empty)
            {
                System.Windows.MessageBox.Show(ApellidosTextBox.Text, "No puede estar vacio");
                ApellidosTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                System.Windows.MessageBox.Show(DireccionTextBox.Text, "No puede estar vacio");
                DireccionTextBox.Focus();
                paso = false;
            }

            if(string.IsNullOrWhiteSpace(CorreoTextBox.Text))
            {
                System.Windows.MessageBox.Show(CorreoTextBox.Text, "No puede estar vacio");
                CorreoTextBox.Focus();
                paso = false;
            }

            if(string.IsNullOrWhiteSpace(TelefonosTextBox.Text))
            {
                System.Windows.MessageBox.Show(TelefonosTextBox.Text, "No puede estar vacio");
                TelefonosTextBox.Focus();
                paso = false;
            }

            return paso;
        }



        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Contactos contactos;
            bool paso = false;

            if (!Validar())
                return;
            contactos = LlenaClase();

            if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                paso = ContactosBLL.Guardar(contactos);

            else
            {
                if (!ExisteBD())
                {
                    System.Windows.MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ContactosBLL.Modificar(contactos);
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

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Contactos contactos = new Contactos();
            int.TryParse(IdTextBox.Text, out id);

            Limpiar();

           contactos = ContactosBLL.Buscar(id);

            if (contactos != null)
            {
                System.Windows.MessageBox.Show("Contacto Encontrada");
                LlenaCampos(contactos);
            }
            else
            {
                System.Windows.MessageBox.Show("Contacto no Encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(IdTextBox.Text);

            Limpiar();

            if (ContactosBLL.Eliminar(id))
                System.Windows.MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                System.Windows.MessageBox.Show(IdTextBox.Text, "No se puede eliminar una contacto que no existe");
        }
    }
}
