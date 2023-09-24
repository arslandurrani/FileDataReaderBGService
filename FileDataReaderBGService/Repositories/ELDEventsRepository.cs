using FileDataReaderBGService.DBContext;
using FileDataReaderBGService.Entities;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDataReaderBGService.Repositories;

public class ELDEventsRepository
{
    private readonly AppDbContext _dbContext;

    public ELDEventsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<ELDEvents> GetAllELDEvents()
    {
        return _dbContext.ELDEvents.AsQueryable();
    }

    public async Task InsertRecordsAsync(List<ELDEvents> records)
    {
        await _dbContext.ELDEvents.AddRangeAsync(records);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<ELDEvents>> GetNonProcessedRecords()
    {
        // Get only required data form the database
        var data = _dbContext.ELDEvents.AsQueryable().Where(x => x.IsProcessed == false);

        return data.ToList();
    }

    public async Task UpdateProcessedRecords(List<ELDEvents> records)
    {
        _dbContext.ELDEvents.UpdateRange(records);
        await _dbContext.SaveChangesAsync();
    }
}
