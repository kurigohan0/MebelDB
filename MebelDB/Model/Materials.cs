//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MebelDB.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materials
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materials()
        {
            this.Specification_materials = new HashSet<Specification_materials>();
        }
    
        public string Vendor_code { get; set; }
        public string Name { get; set; }
        public string Unit_measuring { get; set; }
        public Nullable<double> Length { get; set; }
        public string Quantity { get; set; }
        public string Type_material { get; set; }
        public string Purchase_price { get; set; }
        public string GOST { get; set; }
        public string Main_supplier { get; set; }
        public byte[] Image { get; set; }
        public string Characteristic { get; set; }
    
        public virtual Suppliers Suppliers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specification_materials> Specification_materials { get; set; }
    }
}
