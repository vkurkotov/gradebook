//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gradebook.DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parent : User
    {
        public Parent()
        {
            this.Pupils = new HashSet<Pupil>();
        }
    
        public Nullable<bool> IsParent { get; set; }
        public string Relationship { get; set; }
    
        public virtual ICollection<Pupil> Pupils { get; set; }
    }
}
