using Microsoft.UI.Xaml;
using RenderSharp.CS.RayTracing.HLSL;
using RenderSharp.CS.WinUI.Renderer;

namespace RenderSharp.CS.WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            HlslRayTraceRenderer renderer = new HlslRayTraceRenderer();
            Shader = new RenderViewer<HlslRayTraceRenderer>(renderer);
        }

        public RenderViewer<HlslRayTraceRenderer> Shader;
    }
}
