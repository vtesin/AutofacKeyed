using System;

namespace AutofacKeyed.Wrappers
{
    public class RemoveServiceCommandWrapper<TV, TW> : BaseCommandWrapper<TV, TW>
    {
        protected override TW DoExecute(TV request)
        {
            Console.WriteLine("Connecting to some remote service");
            return default(TW);
        }
    }
}
