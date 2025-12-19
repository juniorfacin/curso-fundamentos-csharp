namespace CursoFundamentos.AppClientes
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public decimal Discount { get; set; }
    }
}
