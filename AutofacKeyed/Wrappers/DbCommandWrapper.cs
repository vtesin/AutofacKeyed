using System;

namespace AutofacKeyed.Wrappers
{
    public class DbCommandWrapper<TV, TW> : BaseCommandWrapper<TV, TW>
    {
        protected override TW DoExecute(TV request)
        {
            Console.WriteLine($"writting {request} to db");

            return default(TW);
        }
    }
}
