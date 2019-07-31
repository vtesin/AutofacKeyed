namespace AutofacKeyed.Model
{
    public sealed class TxnRe : ITxnRe
    {
        public int State { get; set; }

    }

    public interface ITxnRe
    {
        // marker interface
    }
}
