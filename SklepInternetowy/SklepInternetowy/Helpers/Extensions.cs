using System;
using System.Threading.Tasks;

namespace SklepInternetowy.Helpers
{
    public static class Extensions
    {
        public static async Task<bool> HandleRequest(this Task serviceMethod)
        {
            try
            {
                await serviceMethod;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static async Task<T> HandleRequest<T>(this Task<T> serviceMethod) where T : class
        {
            try
            {
                return await serviceMethod;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
