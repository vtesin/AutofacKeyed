namespace AutofacKeyed.Wrappers
{
    public interface ICommandWrapper<in TV, out TW>
    {
        /// <summary>
        /// Do the wrapper logic
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        TW Execute(TV request);
    }
}