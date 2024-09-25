namespace API.DTOs;

public class DeleteContact
{
    public DeleteContact(Guid contactId)
    {
        ContactId = contactId;

    }
    public Guid ContactId { get; set; }
}