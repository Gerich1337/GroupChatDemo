//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GroupChat.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeesChatrooms
    {
        public int Id { get; set; }
        public Nullable<int> EmployeesID { get; set; }
        public Nullable<int> ChatroomsID { get; set; }
    
        public virtual Chatroom Chatroom { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
