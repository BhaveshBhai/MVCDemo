
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace SafetracWebApp.Models
{

using System;
    using System.Collections.Generic;
    
public partial class User
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public User()
    {

        this.UserAreas = new HashSet<UserArea>();

    }


    public int id { get; set; }

    public string first_name { get; set; }

    public string last_name { get; set; }

    public string user_password { get; set; }

    public string email_address { get; set; }

    public Nullable<System.DateTime> date_created { get; set; }

    public Nullable<System.DateTime> date_modified { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<UserArea> UserAreas { get; set; }

}

}
