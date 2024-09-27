namespace Contracts;

public class DeleteContactMessage
{
    public DeleteContactMessage(Guid contactId)
    {
        ContactId = contactId;

    }
    public Guid ContactId { get; set; }
}