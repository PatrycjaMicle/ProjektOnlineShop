using System;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowyServiceReference;

namespace WingtipToys.Logic
{
    public class ShoppingCartService : AListViewModel<ElementKoszyka>
    {
        public ShoppingCartService() : base("Koszyk")
        {
        }

        public int IdSesjiKoszyka { get; set; }

        //TO DO
        public void AddToCart(int idTowaru)
        {
            IdSesjiKoszyka = getCartId();
        }

        //TO DO
        public int getCartId()
        {
            return 1;
        }

        public override void GoToAddPage()
        {
            throw new NotImplementedException();
        }

        public override void OnItemSelected(ElementKoszyka item)
        {
            throw new NotImplementedException();
        }
    }
}