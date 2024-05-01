using System.ComponentModel.DataAnnotations;

namespace IKProjesi.UI.Models.Enums
{
    public enum MoneyType
    {
        [Display(Name = "Türk Lirası")]
        TRY = 1,
        [Display(Name = "ABD Doları")]
        USD,
        [Display(Name = "Avro")]
        EUR,
        [Display(Name = "İngiliz Sterlini")]
        GBP,
        [Display(Name = "Japon Yeni")]
        JPY,
        [Display(Name = "İsviçre Frangı")]
        CHF,
        [Display(Name = "Avustralya Doları")]
        AUD,
        [Display(Name = "Kanada Doları")]
        CAD,
        [Display(Name = "Yeni Zelanda Doları")]
        NZD,
        [Display(Name = "Çin Yuanı")]
        CNY,
        [Display(Name = "Brezilya Reali")]
        BRL,
    }
}
