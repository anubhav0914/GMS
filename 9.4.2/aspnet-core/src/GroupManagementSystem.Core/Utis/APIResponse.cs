using System;
using Abp.Notifications;

namespace GroupManagementSystem.Utis;

public class APIResponse<T>
{
    public APIResponse(T value, string v)
    {
        this.result = value;
        this.message = message;

    }

    public  T result { get; set; }
   public string message { get; set; }

   
}
