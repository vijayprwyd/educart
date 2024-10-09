using Microsoft.EntityFrameworkCore;

namespace PillarResource;

public class PillarService
{
    private readonly CoreDbContext _dbContext;

    public PillarService(CoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Pillar>> GetPillarsAsync()
    {
        return _dbContext.Pillars.ToListAsync();
    }

    public async Task<Pillar> AddPIllarAsync(AddPillarInput addPillarInput)
    {
        var pillar = new Pillar
        {
            Id = Guid.NewGuid(),
            Name = addPillarInput.Name,
            Description = addPillarInput.Description,
            CreatedAt = addPillarInput.CreatedAt,
            UpdatedAt = addPillarInput.UpdatedAt,
        };

        await _dbContext.Pillars.AddAsync(pillar);
        await _dbContext.SaveChangesAsync();

        return pillar;
    }

    public async Task<Pillar> UpdatePillarAsync(Guid id, UpdatePillarInput updatePillarInput)
    {
        var pillar = _dbContext.Pillars.FirstOrDefault(p => p.Id == id);
        if (pillar == null)
            throw new Exception("Pillar id not found");

        if (updatePillarInput.Name != null)
            pillar.Name = updatePillarInput.Name;
        if (updatePillarInput.Description != null)
            pillar.Name = updatePillarInput.Description;
        pillar.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
        return pillar;
    }
}
