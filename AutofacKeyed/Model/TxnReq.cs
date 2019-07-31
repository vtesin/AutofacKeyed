namespace AutofacKeyed.Model
{
    public sealed class TxnReq : ITxnReq
    {
        public int SeqId { get; set; }
        public string Reference { get; set; }
    }

    public class ITxnReq
    {
        // marker interface
    }
}
