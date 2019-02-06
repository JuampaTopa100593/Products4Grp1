using System.Threading.Tasks;
using Xamarin.Forms;

namespace Products4Grp1.Services
{
    public class DialogService
    {
        public async Task ShowMessage(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(
                title,
                message,
                "Acceptar");
        }

    }
}
