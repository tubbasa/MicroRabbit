namespace MicroRabbit.MVC.Models
{
    public class TransferViewModel
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public string TransferNotes { get; set; }
        public decimal TransferAmount { get; set; }
    }
}