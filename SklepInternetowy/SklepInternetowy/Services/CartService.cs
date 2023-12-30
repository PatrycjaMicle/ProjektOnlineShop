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
    }
}
