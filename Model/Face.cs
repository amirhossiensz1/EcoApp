//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Face
    {
        public int ID { get; set; }
        public string FaceData { get; set; }
        public Nullable<int> EmpId { get; set; }
        public string PersonalNum { get; set; }
        public byte[] image { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
