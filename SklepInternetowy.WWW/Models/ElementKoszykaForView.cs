using System;

namespace SklepInternetowy.Models
{
    public class ElementKoszykaForView
    {
        public int IdElementuKoszyka { get; set; }

        public int? IdUzytkownika { get; set; }

        public int? IdTowaru { get; set; }

        public string TowarNazwa { get; set; }

        public double? TowarCena { get; set; }

        public double? Ilosc { get; set; }

        public DateTime? DataUtworzenia { get; set; }
    }
}