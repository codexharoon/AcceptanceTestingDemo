# 💼 Acceptance Testing Demo with SpecFlow (.NET 8)

This repository demonstrates how to implement **Acceptance Testing** in a C# project using **SpecFlow**, **NUnit**, and **.NET 8**.  
It simulates real-world user scenarios like adding and removing products from a list, verified through **business-readable Gherkin syntax**.

---

## 🧪 What is This Project?

A practical example of:
- ✅ Acceptance testing using **SpecFlow**
- ✅ Writing business-readable scenarios in **Gherkin**
- ✅ Connecting scenarios to C# logic using **step definitions**
- ✅ Ensuring the software meets **business/user requirements**

---

## 📁 Technologies Used

- .NET 8  
- C#  
- SpecFlow  
- NUnit  
- VS Code / CLI

---

## 📂 Project Structure

```
ACCEPTANCETEST/
├── bin/                        # Build output
├── Feature/                   # SpecFlow feature files (.feature)
│   └── ProductManagement.feature
├── obj/                        # Build temp files
├── Steps/                     # SpecFlow step definitions
│   └── ProductManagementSteps.cs
├── .gitignore
├── AcceptanceTest.csproj      # Test project file
├── AcceptanceTest.sln         # Solution file
├── ProductManager.cs          # Core product logic (in-memory list)
├── UnitTest1.cs               # (Optional) basic NUnit test file
└── README.md
```

---

## 💡 Sample Feature File (Gherkin)

```gherkin
Feature: Product management
  To manage products
  As a user
  I want to add and remove products from a list

  Scenario: Add a product to the list
    Given the product list is empty
    When I add "Apple"
    Then the product list should contain "Apple"

  Scenario: Remove a product from the list
    Given the product list has "Banana"
    When I remove "Banana"
    Then the product list should not contain "Banana"
```

---

## 🧩 Step Definition Example

```csharp
using NUnit.Framework;
using ProductApp;
using TechTalk.SpecFlow;

namespace ProductApp.AcceptanceTests.StepDefinitions;

[Binding]
public class ProductManagementSteps
{
    private ProductManager _productManager;

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

    [Then(@"the product list should contain ""(.*)""")]
    public void ThenTheProductListShouldContain(string product)
    {
        Assert.Contains(product, _productManager.GetAllProducts());
    }

    [Then(@"the product list should not contain ""(.*)""")]
    public void ThenTheProductListShouldNotContain(string product)
    {
        Assert.IsFalse(_productManager.GetAllProducts().Contains(product));
    }
}
```

---

## 🚀 How to Run

1. Install [.NET SDK 8](https://dotnet.microsoft.com/en-us/download)
2. Clone the repository:

```bash
git clone https://github.com/yourusername/AcceptanceTestingDemo.git
cd AcceptanceTestingDemo
```

3. Restore dependencies and run the tests:

```bash
dotnet restore
dotnet test
```

---

## 👨‍💻 Author Info

**Muhammad Haroon**  
💼 CTO | Full Stack & Mobile Developer  
📧 Email: [info@codexharoon.com](mailto:info@codexharoon.com)  
🌐 Website: [https://codexharoon.com](https://codexharoon.com)

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

---

## 🙌 Contributing

Contributions are welcome! Feel free to fork the repo and submit a pull request.
