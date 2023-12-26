using SklepInternetowy.Services.DataStore;
using SklepInternetowy.ViewModels.Abstract;
using SklepInternetowyServiceReference;
using System;


namespace WingtipToys.Logic
{
    public class ShoppingCartService : AListViewModel<ElementKoszyka>
    {
        public int IdSesjiKoszyka { get; set; }

        public ShoppingCartService() : base("Koszyk")
        {
        }

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