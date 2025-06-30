namespace AcceptanceTest;

public class ProductManager
{
    private readonly List<string> _products = new();

    public void AddProduct(string productName)
    {
        _products.Add(productName);
    }

    public void RemoveProduct(string productName)
    {
        _products.Remove(productName);
    }

    public List<string> GetAllProducts()
    {
        return _products;
    }
}
