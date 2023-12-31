using SklepInternetowy.Services;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.ViewModels
{
    public class SzczegolyZamowieniaViewModel : AListViewModel<TowarZamowienium>
    {
        private double? suma;
        public double? Suma
        {
            get { return suma; }
            set
            {
                if (suma != value)
                {
                    suma = value;
                    OnPropertyChanged(nameof(Suma));
                }
            }
        }
        public SzczegolyZamowieniaViewModel() : base("wroc do koszyka")
        {
            Suma = CartService.Suma;
            CartService.Suma = 0;
        }

        public override void GoToAddPage()
        {
        }

        public override void OnItemSelected(TowarZamowienium item)
        {
        }
    }

}
