namespace Catalog.Features.Products.Domain;

public class Product : Aggregate<Guid>
{
    public string Name { get; private set; } = null!;
    public IReadOnlyList<string> Category { get; private set; } = [];
    public string Description { get; private set; } = null!;
    public string ImageFile { get; private set; } = null!;
    public decimal Price { get; private set; }

    public static Product Create(Guid id, string name, List<string> category, string description, string imageFile,
        decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentNullException.ThrowIfNull(category);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product
        {
            Id = id,
            Name = name,
            Category = category.ToList(),
            Description = description,
            ImageFile = imageFile,
            Price = price
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));

        return product;
    }

    public void Update(string name, List<string> category, string description, string imageFile, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentNullException.ThrowIfNull(category);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        // Update Product entity fields
        Name = name;
        Category = category.ToList();
        Description = description;
        ImageFile = imageFile;

        // if price has changed, raise ProductPriceChanged domain event
        if (Price != price)
        {
            Price = price;
            AddDomainEvent(new ProductPriceChangedEvent(this));
        }
    }
}