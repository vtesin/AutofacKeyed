namespace AutofacKeyed.Wrappers
{
    public abstract class BaseCommandWrapper<TV, TW> : ICommandWrapper<TV, TW>
    {
        protected abstract TW DoExecute(TV request);

        public TW Execute(TV request)
        {
            return DoExecute(request);
        }
    }
}
