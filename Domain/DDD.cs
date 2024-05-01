namespace Domain
{
    public class DDD
    {
        public DDD(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Region { get; set; } = string.Empty;
        public List<Contact> Contacts { get; set; }
    }
}