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

            //-------------------------
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping("MyCustomWindow", (handler, view) =>
            {
#if WINDOWS
                        var nativeWindow = handler.PlatformView as Microsoft.UI.Xaml.Window;
                        if (nativeWindow != null)
                        {
                            var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
                            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                            var presenter = appWindow.Presenter as Microsoft.UI.Windowing.OverlappedPresenter;

                            if (presenter != null)
                            {
                                presenter.IsMinimizable = true;
                                presenter.IsMaximizable = false;
                                presenter.IsResizable = false;
                                presenter.Maximize();

                                // EVENTO DE LOG E TRAVA
                                appWindow.Changed += (sender, args) =>
                                {
                                    // Se a mudança foi no tamanho (Size) ou no apresentador (Presenter)
                                    if (args.DidSizeChange || args.DidPresenterChange)
                                    {
                                        // Verificamos se ela NÃO está minimizada (para deixar o botão '-' funcionar)
                                        // E se ela NÃO está maximizada (o que significa que o duplo clique tentou agir)
                                        if (presenter.State != Microsoft.UI.Windowing.OverlappedPresenterState.Minimized && 
                                            presenter.State != Microsoft.UI.Windowing.OverlappedPresenterState.Maximized)
                                        {
                                            // Forçamos a volta imediata para o tamanho grande
                                            presenter.Maximize();
                                            System.Diagnostics.Debug.WriteLine("Tentativa de redimensionamento via duplo clique bloqueada!");
                                        }
                                    }
                                };
                                // FIM EVENTO DE LOG E TRAVA

                            }
                        }
#endif
            });
            //-------------------------

            return window;

        }
    }
}