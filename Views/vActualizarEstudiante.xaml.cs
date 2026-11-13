using System.Collections.Specialized;
using System.Net;
using ddelgadoS6.Models;

namespace ddelgadoS6.Views;

public partial class vActualizarEstudiante : ContentPage
{
	public vActualizarEstudiante(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    public async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            string url = "http://192.168.56.1:80/ws_estudiante/estudiante_ws.php"
                    + "?codigo=" + Uri.EscapeDataString(txtCodigo.Text)
                    + "&nombre=" + Uri.EscapeDataString(txtNombre.Text)
                    + "&apellido=" + Uri.EscapeDataString(txtApellido.Text)
                    + "&edad=" + Uri.EscapeDataString(txtEdad.Text);
            cliente.UploadString(url, "PUT", "");

            await DisplayAlert("Correcto", "Estudiante actualizado", "OK");
            await Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", "Error " + ex.Message, "OK");
        }
    }
    public async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        bool respuesta = await DisplayAlert( "Confirmar",
                "¿Está seguro de eliminar este estudiante?", "Sí", "No");

        if (respuesta)
        {
            try
            {
                WebClient cliente = new WebClient();
                string url = "http://192.168.56.1:80/ws_estudiante/estudiante_ws.php"
                        + "?codigo=" + Uri.EscapeDataString(txtCodigo.Text);
                cliente.UploadString(url, "DELETE", "");

                await DisplayAlert("Correcto", "Estudiante eliminado", "OK");
                await Navigation.PushAsync(new vEstudiante());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error " + ex.Message, "OK");
            }
        }
    }
}