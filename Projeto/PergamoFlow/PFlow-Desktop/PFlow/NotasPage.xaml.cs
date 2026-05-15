namespace PFlow_Desktop;

public partial class NotasPage : ContentPage
{
	public NotasPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Quando esta página aparecer, ela muda o título da janela pai
        if (this.Window != null)
        {
            this.Window.Title = "PFlow - Lançamento de Notas";
        }
    }

}