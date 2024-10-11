using PillarResource;

public interface IPillarService
{
    public Task<List<Pillar>> GetPillarsAsync();
    public Task<Pillar> GetPillarByIdAsync(Guid id);
    public Task<Pillar> AddPIllarAsync(AddPillarInput addCourseInput);
    public Task<Pillar> UpdatePillarAsync(Guid id, UpdatePillarInput updateCourseInput);
    public Task DeletePillarAsync(Guid id);
}

public interface IPillarQuery
{
    public Task<Pillar> GetPillar(Guid id);
    public Task<List<Pillar>> GetPillars();
}

public interface IPillarMutation
{
    public Task<Pillar> AddPillar(AddPillarInput addCourseInput);
    public Task<Pillar> UpdatePillar(Guid id, UpdatePillarInput updateCourseInput);
    public Task DeletePillar(Guid id);
}
