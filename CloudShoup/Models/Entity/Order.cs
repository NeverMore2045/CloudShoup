namespace CloudShoup.Models.Entity
{
    // zakaz
    public class Order
    {
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public string? Description { get; set; }
        public override string ToString()
        {
            return $"Client: {ClientName} , Description{Description}";
        }
    }
}
