using FileDataReaderBGService.DBContext;
using FileDataReaderBGService.Entities;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDataReaderBGService.Repositories;

public class ELDEventsServerRepository
{
    private readonly AppDbContext _dbContext;

    public ELDEventsServerRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InsertRecordsAsync(List<ELDEventsServer> records)
    {
        await _dbContext.ELDEventsServer.AddRangeAsync(records);
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<ELDEventsServer> GetAllELDEvents()
    {
        return _dbContext.ELDEventsServer.AsQueryable();
    }
}
