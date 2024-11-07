using glasluisaS6B.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;

namespace glasluisaS6B.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://192.168.17.3/wsestudiantes/estudiante.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;
	public vEstudiante()
	{
        InitializeComponent();
		Listar();
	}

	public async void Listar()
	{
	var content = await cliente.GetStringAsync(Url);
	List<Estudiante> ListaEstudiante = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(ListaEstudiante);
        lvEstudiantes.ItemsSource = estud;
	}
}