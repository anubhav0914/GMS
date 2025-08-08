using System;

namespace GroupManagementSystem.DTOS;

public class PaymentStructureRequestDTO
{
    public string Name { get; set; }
    public long GroupId { get; set; }
}

public class PaymentStructureUpdateDTO : PaymentStructureRequestDTO
{
    public int id { get; set; }
}
