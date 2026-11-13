using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ddelgadoS6.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://192.168.56.1:80/ws_estudiante/estudiante_ws.php";
	private readonly HttpClient _cliente = new HttpClient();
	private ObservableCollection<Models.Estudiante> _estudiante;

    public vEstudiante()
	{
		InitializeComponent();
		MostrarEstudiante();
    }

	public async void MostrarEstudiante()
    {
        var content = await _cliente.GetStringAsync(Url);
        List<Models.Estudiante> _mostrar = JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);
		_estudiante = new ObservableCollection<Models.Estudiante>(_mostrar);
		listaEstudiante.ItemsSource = _estudiante;
    }

	public void btnAgregarEstudiante_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vAgregarEstudiante());
    }

	public void listaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var ObjetoEstudiante = (Models.Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vActualizarEstudiante(ObjetoEstudiante));
    }
}