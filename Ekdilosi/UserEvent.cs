//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ekdilosi
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserEvent
    {
        public int User_Id { get; set; }
        public int Event_Id { get; set; }
    
        public virtual EventDetail EventDetail { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
