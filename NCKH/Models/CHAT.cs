//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NCKH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHAT
    {
        public int MACHAT { get; set; }
        public Nullable<int> MAKH { get; set; }
        public Nullable<int> MAADM { get; set; }
        public string NOIDUNGTINNHAN { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
    
        public virtual ADMIN ADMIN { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}