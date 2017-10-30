using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XF.Recursos.Droid;
using XF.Recursos.API;
using Xamarin.Geolocation;
using System.Threading.Tasks;
using Xamarin.Media;

[assembly: Dependency(typeof(GeoLocation_Android))]
namespace XF.Recursos.Droid
{
    public class Camera_Android : ICamera
    {
        public void CapturarFoto()
        {
            var context = Forms.Context as Activity;
            var captura = new MediaPicker(context);

            var intent = captura.GetTakePhotoUI(new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Rear,
                Name = string.Format("foto_{0}.jpg", DateTime.Now.ToString()),
                Directory = "Fiap"
            });
            context.StartActivityForResult(intent, 1);
        }

        public void SelecionarFoto()
        {
            var context = Forms.Context as Activity;
            var captura = new MediaPicker(context);

            var intent = captura.GetPickPhotoUI();
            context.StartActivityForResult(intent, 1);
        }
    }
}