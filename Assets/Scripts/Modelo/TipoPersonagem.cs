﻿using System;
using System.ComponentModel;
using System.Linq;

namespace Assets.Scripts
{
    public enum TipoPersonagem
    {
        [Description("Negrinho do Pastoreiro")]
        Negrinho_Pastoreiro,

        [Description("Vitória Regia")]
        Vitoria_Regia,

        [Description("Boto Cor-De-Rosa")]
        Boto,

        [Description("Curupira")]
        Curupira,

        [Description("Saci Pererê")]
        Saci,

        [Description("Mula Sem Cabeça")]
        Mula_Sem_Cabeca,

        [Description("Boitata")]
        Boitata,

        [Description("Iara, Mãe da Água")]
        Iara,

        [Description("Cuca")]
        Cuca,
    }
    public static class EnumHelper
    {
    
        public static string GetEnumDescription(this TipoPersonagem value)
        {
            Type type = typeof(TipoPersonagem);
            
            var field = type.GetField(value.ToString());
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : "";
        }
    }
}
