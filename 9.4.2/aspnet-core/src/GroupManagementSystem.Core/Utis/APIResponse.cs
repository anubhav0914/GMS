using System;
using Abp.Notifications;

namespace GroupManagementSystem.Utis;

public class APIResponse<T>
{
    

public  T result { get; set; }
   public string message { get; set; }

   
}
