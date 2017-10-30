using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.GPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoordenadaView : ContentPage
    {
        public CoordenadaView()
        {
            InitializeComponent();
        }

        public void btnCoordenada_Clicked()
        {
            var servico = DependencyService.Get<ILocalizacao>();
            servico.GetCoordenada();

            MessagingCenter.Subscribe<ILocalizacao, Coordenada>(this, "coordenada",
                (localizacao, coordenada) =>
                {
                    lblLatitude.Text = coordenada.Latitude;
                    lblLongitude.Text = coordenada.Longitude;
                });
        }
    }
}