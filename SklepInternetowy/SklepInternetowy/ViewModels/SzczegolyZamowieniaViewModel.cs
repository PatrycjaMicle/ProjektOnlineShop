using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SklepInternetowy.Services;
using SklepInternetowy.Services.DataStore;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class SzczegolyZamowieniaViewModel : AListViewModel<TowarZamowienium>
    {
        public SzczegolyZamowieniaViewModel() : base("wroc do koszyka")
        {
        }

        public override void GoToAddPage()
        {
        }


        public override void OnItemSelected(TowarZamowienium item)
        {
        }
    }

}
