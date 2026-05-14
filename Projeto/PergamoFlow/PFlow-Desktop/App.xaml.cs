using Microsoft.Extensions.DependencyInjection;

namespace PFlow_Desktop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new AppShell());



            // Criamos a janela apontando para a sua página Principal
            var window = new Window(new NavigationPage(new Principal()));

            // Injetamos as configurações de comportamento do Windows
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping("MyCustomWindow", (handler, view) =>
            {


#if WINDOWS
                // O 'handler.PlatformView' é a janela real do Windows
                var nativeWindow = handler.PlatformView as Microsoft.UI.Xaml.Window;
                
                if (nativeWindow != null)
                {
                    // Agora sim conseguimos pegar o Handle da janela nativa
                    var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                    var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
                    
                    var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                    var presenter = appWindow.Presenter as Microsoft.UI.Windowing.OverlappedPresenter;



                    if (presenter != null)
                    {
                        // Define o estilo da janela antes de qualquer coisa
                        // Overlapped é o padrão, mas vamos travar as capacidades dela
                        presenter.IsMinimizable = true;   // Minimizar: OK
                        presenter.IsMaximizable = false;  // Botão de restaurar: Desabilitado
                        presenter.IsResizable = false;    // Impede o redimensionamento (e o duplo clique)
    
                        // Agora forçamos o estado maximizado
                        presenter.Maximize();

                        // DICA EXTRA: Remove o menu de sistema (que aparece ao clicar no ícone do app)
                        // Isso impede que o usuário selecione "Restore" por lá.
                        // appWindow.TitleBar.ExtendsContentIntoTitleBar = false;
                    }


                }
#endif


            });

            return window;



        }
    }
}