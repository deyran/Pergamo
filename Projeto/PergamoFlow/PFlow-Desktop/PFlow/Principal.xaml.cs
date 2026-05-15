namespace PFlow_Desktop;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private async void OnLancarNotasClicked(object sender, EventArgs e)
    {
        // Navega para a NotasPage que acabamos de criar
        // O PushAsync coloca a tela de notas na frente da principal
        await Navigation.PushAsync(new NotasPage());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Quando esta página aparecer, ela muda o título da janela pai
        if (this.Window != null)
        {
            this.Window.Title = "PFlow";
        }
    }
}