using System.Net;

namespace ddelgadoS6.Views;

public partial class vAgregarEstudiante : ContentPage
{
	public vAgregarEstudiante()
	{
		InitializeComponent();
	}

	public void btnAgregar_Clicked(object sender, EventArgs e)
	{
		try 
		{
			WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.56.1:80/ws_estudiante/estudiante_ws.php", "POST", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Alerta", "Error " + ex.Message, "OK");
        }
    }

    public void btnCancelar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vEstudiante());
    }
}