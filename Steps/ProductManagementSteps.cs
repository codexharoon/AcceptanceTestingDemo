using NUnit.Framework;
using AcceptanceTest;
using TechTalk.SpecFlow;

namespace AcceptanceTest.Steps;

[Binding]
public class ProductManagementSteps
{
    private ProductManager _productManager;
    private string _checkedProduct;

    [Given(@"the product list is empty")]
    public void GivenTheProductListIsEmpty()
    {
        _productManager = new ProductManager();
    }

    [Given(@"the product list has ""(.*)""")]
    public void GivenTheProductListHas(string product)
    {
        _productManager = new ProductManager();
        _productManager.AddProduct(product);
    }

    [When(@"I add ""(.*)""")]
    public void WhenIAdd(string product)
    {
        _productManager.AddProduct(product);
    }

    [When(@"I remove ""(.*)""")]
    public void WhenIRemove(string product)
    {
        _productManager.RemoveProduct(product);
    }

    [When(@"I check for ""(.*)""")]
    public void WhenICheckFor(string product){
        var products = _productManager.GetAllProducts();
        _checkedProduct = products.Contains(product) ? product : "";
    }

    [Then(@"the product list should contain ""(.*)""")]
    public void ThenTheProductListShouldContain(string product)
    {
        var products = _productManager.GetAllProducts();
        Assert.Contains(product, products);
    }

    [Then(@"the product list should contain checked ""(.*)""")]
    public void ThenTheProductListShouldContainChecked(string product)
    {
        Assert.AreEqual(product, _checkedProduct);
    }

    [Then(@"the product list should not contain ""(.*)""")]
    public void ThenTheProductListShouldNotContain(string product)
    {
        var products = _productManager.GetAllProducts();
        Assert.IsFalse(products.Contains(product));
    }
}
