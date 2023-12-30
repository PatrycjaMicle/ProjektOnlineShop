using System;

namespace SklepInternetowy.Services
{
    public static class CartService
    {
        private static double? _suma;

        public static double? Suma
        {
            get { return _suma; }
            set
            {
                if (_suma != value)
                {
                    _suma = value;
                    OnSumaChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        public static event EventHandler OnSumaChanged;

        private static int? _idZamowienia;

        public static int? IdZamowienia
        {
            get { return _idZamowienia; }
            set
            {
                if (_idZamowienia != value)
                {
                    _idZamowienia = value;
                    OnIdZamowieniaChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        public static event EventHandler OnIdZamowieniaChanged;
    }
}
