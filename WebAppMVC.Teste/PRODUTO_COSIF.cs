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
    
    public partial class PRODUTO_COSIF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUTO_COSIF()
        {
            this.MOVIMENTO_MANUAL = new HashSet<MOVIMENTO_MANUAL>();
        }
    
        public string COD_COSIF { get; set; }
        public string COD_PRODUTO { get; set; }
        public string COD_CLASSIFICACAO { get; set; }
        public string STA_STATUS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO_MANUAL> MOVIMENTO_MANUAL { get; set; }
        public virtual PRODUTO PRODUTO { get; set; }
    }
}
