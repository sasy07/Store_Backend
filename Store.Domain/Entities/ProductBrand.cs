using Store.Domain.Entities.Base;

namespace Store.Domain.Entities;

public class ProductBrand : BaseAuditableEntity, ICommands
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDelete { get; set; } = false;
    public string Summary { get; set; }
}