namespace TreeFolder.DAL.Common
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
