using Api01.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Api01.Domain.Entities;

public sealed class Purchase
{
    public int Id { get; private set; }

    public int ProductId { get; private set; }

    public int PersonId { get; private set; }

    public DateTime Date { get; private set; }

    public Person Person { get; set; }
    public Product Product { get; set; }

    public Purchase(int productId, int personId, DateTime? date)
    {
        Validation(productId, personId, date);
    }

    public Purchase(int id, int productId, int personId, DateTime? date)
    {
        DomainValidationExceptions.When(id < 0, "Id inválido!");
        Id = id;
        Validation(productId, personId, date);
    }


    private void Validation(int productId, int personId, DateTime? date)
    {
        DomainValidationExceptions.When(productId < 0, "Produto deve ser informado!");
        DomainValidationExceptions.When(personId < 0, "Pessoa deve ser informado!");
        DomainValidationExceptions.When(!date.HasValue, "Data da compra deve ser informado!");

        ProductId = productId;
        PersonId = personId;
        Date = date.Value;
    }

}
