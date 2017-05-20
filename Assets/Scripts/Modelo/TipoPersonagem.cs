using System;
using System.ComponentModel;

namespace Assets.Scripts
{
    public enum TipoPersonagem
    {
        [Description("Negrinho do Pastoreiro")]
        Negrinho_Pastoreiro,

        [Description("Vitória Regia")]
        Vitoria_Regia,

        [Description("Boto cor-de-rosa")]
        Boto,

        [Description("Curupira")]
        Curupira,

        [Description("Saci Pererê")]
        Saci,

        [Description("Mula sem cabeça")]
        Mula_Sem_Cabeca,

        [Description("Boitata")]
        Boitata,

        [Description("Iara, mãe da água")]
        Iara,

        [Description("Cuca")]
        Cuca,
    }
    public static class EnumHelper
    {
       public static string GetDescription(this TipoPersonagem enumVal)
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(type, false);
            return (attributes.Length > 0) ? attributes[0].ToString() : null;
        }
    }
}
