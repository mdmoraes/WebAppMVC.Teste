//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppMVC.Teste
{
    using System;
    using System.Collections.Generic;
    
    public partial class MOVIMENTO_MANUAL
    {
        public decimal DAT_MES { get; set; }
        public decimal DAT_ANO { get; set; }
        public decimal NUM_LACAMENTO { get; set; }
        public string COD_PRODUTO { get; set; }
        public string COD_COSIF { get; set; }
        public string DES_DESCRICAO { get; set; }
        public System.DateTime DAT_MOVIMENTO { get; set; }
        public string COD_USUARIO { get; set; }
        public decimal VAL_VALOR { get; set; }
    
        public virtual PRODUTO_COSIF PRODUTO_COSIF { get; set; }
    }
}
