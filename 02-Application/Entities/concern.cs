//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resotel.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class concern
    {
        public int feature_id { get; set; }
        public int booking_id { get; set; }
        public Nullable<System.DateTime> fearture_date_start { get; set; }
        public Nullable<System.DateTime> fearture_date_end { get; set; }
    
        public virtual booking booking { get; set; }
        public virtual feature feature { get; set; }
    }
}
