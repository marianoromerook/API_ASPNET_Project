namespace API_RESTful_Project.Services
{
    public interface IDataService
    {
        // Métodos para la creación de datos
        Task<T> CreateAsync<T>(T data) where T : class;
        Task<IEnumerable<T>> CreateManyAsync<T>(IEnumerable<T> data) where T : class;

        // Métodos para la actualización de datos
        Task<T> UpdateAsync<T>(T data) where T : class;

        // Métodos para la eliminación de datos
        Task<bool> DeleteAsync<T>(int id) where T : class;
        Task<bool> DeleteAsync<T>(T data) where T : class;
    }
}
