//------------------------------------------------------------------------------
// <auto-generated>
//    Bu kod bir şablondan oluşturuldu.
//
//    Bu dosyada el ile yapılan değişiklikler uygulamanızda beklenmedik davranışa neden olabilir.
//    Kod yeniden oluşturulursa, bu dosyada el ile yapılan değişikliklerin üzerine yazılacak.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    
    public partial class action
    {
        public int id { get; set; }
        public int statusid { get; set; }
        public int registerid { get; set; }
        public string description { get; set; }
    
        public virtual register register { get; set; }
        public virtual status status { get; set; }
    }
}
