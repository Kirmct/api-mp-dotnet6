using Api01.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api01.Domain.Entities;

public sealed class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string CodeErp { get; private set; }
    public decimal Price { get; private set; }

    public ICollection<Purchase> Purchases { get; set; }

    public Product(string name, string codeErp, decimal price)
    {
        Validation(name, codeErp, price);
        Purchases = new List<Purchase>();

    }

    public Product(int id, string name, string codeErp, decimal price)
    {
        DomainValidationExceptions.When(id < 0, "Id Inválido");
        Id = id;
        Validation(name, codeErp, price);
        Purchases = new List<Purchase>();


    }

    private void Validation(string name, string codeErp, decimal price)
    {
        DomainValidationExceptions.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
        DomainValidationExceptions.When(string.IsNullOrEmpty(codeErp), "Código Erp deve ser informado!");
        DomainValidationExceptions.When(price < 0, "Preço deve ser informado!");

        Name = name;
        CodeErp = codeErp;
        Price = price;
    }

}
