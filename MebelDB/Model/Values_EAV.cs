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
    
    public partial class Values_EAV
    {
        public int id_value { get; set; }
        public int id_specification { get; set; }
        public string marking { get; set; }
        public string value { get; set; }
    
        public virtual Specifications_EAV Specifications_EAV { get; set; }
    }
}