using Bogus;
using Bogus.DataSets;
using Domain;
using Domain.DTOs;

namespace TechChallenge.Tests.Entitiy;

public class ContactBuilder
{
    public static ContactDTO Build()
    {
        var contact = new Faker<ContactDTO>()
            .RuleFor(c => c.Name, (f) => f.Person.FullName)
            .RuleFor(u => u.Phone, f => string.Concat(f.Random.Int(10, 99), f.Phone.PhoneNumber("9########"))
                .Replace("!", $"{f.Random.Int(min: 1, max: 9)}"))
            .RuleFor(c => c.Email, (f) => f.Internet.Email(f.Person.FullName));

        return contact;
    }
}
