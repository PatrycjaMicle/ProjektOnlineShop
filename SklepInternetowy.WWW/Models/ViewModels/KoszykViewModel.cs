namespace SklepInternetowy.WWW.Models.ViewModels
{
    public class KoszykViewModel
    {
        public List<ElementKoszykaForView> ElementyKoszyka { get; set; }
        public double? znizkaInit {  get; set; }
        public double? znizka {  get; set; }
        public double? suma {  get; set; }
        public double? sumaPoZnizce {  get; set; }
    }
}
