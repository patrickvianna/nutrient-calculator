using System.ComponentModel;

namespace NutrientCalculator.App.Entities.Enums
{
    public enum eNutrient
    {
        Nulo,
        [Description("Calorias")]
        Calorias,
        [Description("Carboidratos g")]
        Carboidratos,
        [Description("Proteínas")]
        Proteinas,
        [Description("Gorduras totais g")]
        GordurasTotais,
        [Description("Gorduras saturadas g")]
        GordurasSaturadas,
        [Description("Gorduras trans g")]
        GordurasTrans,
        [Description("Fibra alimentar g")]
        FibraAlimentar,
        [Description("Colesterol mg")]
        Colesterol,
        [Description("Sódio mg")]
        Sodio,
        [Description("Potássio mg")]
        Potassio,
        [Description("Vitamina A IU")]
        VitaminaA,
        [Description("Vitamina B2 mg")]
        VitaminaB2,
        [Description("Vitamina B6 mg")]
        VitaminaB6,
        [Description("Vitamina C mg")]
        VitaminaC,
        [Description("Vitamina D mg")]
        VitaminaD,
        [Description("Vitamina E mg")]
        VitaminaE,
        [Description("Cálcio mg")]
        Calcio,
        [Description("Ferro mg")]
        Ferro,
        [Description("Fósforo mg")]
        Foscoro,
        [Description("Magnésio mg")]
        Magnesio,
        [Description("Selênio mg")]
        Selenio,
        [Description("Glutamina mg")]
        Glutamina,
        [Description("Glicina Cisteína mg")]
        GlicinaCisteina,
        [Description("Taurina mg")]
        Taurina,
    }
}
