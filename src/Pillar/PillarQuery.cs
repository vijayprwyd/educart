namespace PillarResource;

public class PillarQuery : IPillarQuery
{
    PillarService _pillarService;

    public PillarQuery(PillarService courseService)
    {
        _pillarService = courseService;
    }

    public async Task<Pillar> GetPillar(Guid id)
    {
        return await _pillarService.GetPillarByIdAsync(id);
    }

    public async Task<List<Pillar>> GetPillars()
    {
        return await _pillarService.GetPillarsAsync();
    }
}
