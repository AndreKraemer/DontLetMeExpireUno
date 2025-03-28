using DontLetMeExpireUno.Models;

namespace DontLetMeExpireUno.Services;

public interface IStorageLocationService
{
  Task<IEnumerable<StorageLocation>> GetAsync();
  Task<StorageLocation?> GetByIdAsync(string id);
  Task SaveAsync(StorageLocation storageLocation);
  Task DeleteAsync(StorageLocation storageLocation);
  Task DeleteAllAsync();
}
