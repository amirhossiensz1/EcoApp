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
    
    public partial class TrafficLog
    {
        public int ID { get; set; }
        public string Time { get; set; }
        public Nullable<int> DeviceID { get; set; }
        public string DeviceSerialNumber { get; set; }
        public string ReaderNo { get; set; }
        public string PersonalNum { get; set; }
        public Nullable<int> EmpID { get; set; }
        public Nullable<int> Mode { get; set; }
        public Nullable<int> Type { get; set; }
        public string Date { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<bool> SuccessPass { get; set; }
        public string TimeOfSpi { get; set; }
        public Nullable<bool> Access { get; set; }
        public string ReqType { get; set; }
    }
}
