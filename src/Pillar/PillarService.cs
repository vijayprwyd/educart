using Microsoft.EntityFrameworkCore;

namespace PillarResource;

public class PillarService : IPillarService
{
    private readonly CoreDbContext _dbContext;

    public PillarService(CoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Pillar> GetPillarByIdAsync(Guid pillarId)
    {
        var pillar = await _dbContext.Pillars.FirstOrDefaultAsync(p => p.Id == pillarId);
        if (pillar == null)
            throw new InvalidOperationException("PIllar not found");
        return pillar;
    }

    public Task<List<Pillar>> GetPillarsAsync()
    {
        return _dbContext.Pillars.ToListAsync();
    }

    public async Task<Pillar> AddPIllarAsync(AddPillarInput input)
    {
        var pillar = new Pillar
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            Description = input.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        await _dbContext.Pillars.AddAsync(pillar);
        await _dbContext.SaveChangesAsync();

        return pillar;
    }

    public async Task<Pillar> UpdatePillarAsync(Guid id, UpdatePillarInput updatePillarInput)
    {
        var pillar = await GetPillarByIdAsync(id);
        if (updatePillarInput.Name != null)
            pillar.Name = updatePillarInput.Name;
        if (updatePillarInput.Description != null)
            pillar.Name = updatePillarInput.Description;
        pillar.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
        return pillar;
    }

    public async Task DeletePillarAsync(Guid pillarId)
    {
        var pillar = await GetPillarByIdAsync(pillarId);
        _dbContext.Pillars.Remove(pillar);
        await _dbContext.SaveChangesAsync();
    }
}
