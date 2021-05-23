namespace MicroRabbit.MVC.Models.DTO
{
    public class TransferDto
    {
        public int AccountSource { get; set; }
        public int AccountTarget { get; set; }
        public decimal TransferAmount { get; set; }
    }
}