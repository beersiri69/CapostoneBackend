//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Backendtest.DbContxt
{
    using System;
    using System.Collections.Generic;
    
    public partial class Driver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver()
        {
            this.Deliver = new HashSet<Deliver>();
        }
    
        public string Driver_ID { get; set; }
        public string Driver_Title { get; set; }
        public string Driver_Name { get; set; }
        public string Driver_Surname { get; set; }
        public string Driver_Tel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deliver> Deliver { get; set; }
    }
}