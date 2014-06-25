namespace ClassLibrary1
{
    public interface ILogService
    {
        void Write(string message, params object[] param);
    }
}