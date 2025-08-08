using System;

namespace GroupManagementSystem.DTOS;

public class PaymentStructureUpdateDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string NewName { get; set; }

    public long GroupId { get; set; }
}
