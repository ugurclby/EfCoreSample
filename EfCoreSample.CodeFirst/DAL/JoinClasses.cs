namespace EfCoreSample.CodeFirst.DAL;
public class Customer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; }

}

public class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public decimal TotalAmount { get; set; }

    public string Status { get; set; }
}

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }

    public string ProductName { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

}

public class CustomerWithOrder
{
    public int CustomerId { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }
    public decimal TotalAmount { get; set; }
}


public class OrderWithDetail
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow; 
    public decimal TotalAmount { get; set; }
    public string ProductName { get; set; }
}