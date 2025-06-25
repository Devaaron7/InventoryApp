namespace InventoryApp.Data
{
    public abstract class BaseRepository
    {
        protected readonly string _connectionString;

        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
