// Models/User.cs
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("contacts")]
    public Contacts Contacts { get; set; }

    [BsonElement("expenses")]
    public List<ExpenseReference> Expenses { get; set; }

    [BsonElement("incomes")]
    public List<IncomeReference> Incomes { get; set; }
}

public class Contacts
{
    [BsonElement("phone")]
    public string Phone { get; set; }

    [BsonElement("address")]
    public string Address { get; set; }
}

public class ExpenseReference
{
    [BsonElement("expenseId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ExpenseId { get; set; }
}

public class IncomeReference
{
    [BsonElement("incomeId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string IncomeId { get; set; }
}
