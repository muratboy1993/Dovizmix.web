namespace Infrastructure.Utility.Abstract
{
    public interface ICodeGenerator
    {
        string Create(sbyte length = 6);
    }
}
