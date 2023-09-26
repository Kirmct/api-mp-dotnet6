using Api01.Domain.Validations;

namespace Api01.Domain.Entities;

public sealed class Person
{

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Phone { get; private set; }

    public ICollection<Purchase> Purchases { get; set; }

    public Person()
    {        
    }

    public Person(string name, string document, string phone)
    {
        Validation(name, document, phone);
        Name = name;
        Document = document;
        Phone = phone;
    }

    public Person(int id, string name, string document, string phone)
    {
        DomainValidationExceptions.When(id < 0, "Id inválido!");
        Validation(name, document, phone);
        Id = id;
        Name = name;
        Document = document;
        Phone = phone;
    }

    private void Validation(string name, string document, string phone)
    {
        DomainValidationExceptions.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
        DomainValidationExceptions.When(string.IsNullOrEmpty(document), "Documento deve ser informado!");
        DomainValidationExceptions.When(string.IsNullOrEmpty(phone), "Telefone deve ser informado!");
    }
}
