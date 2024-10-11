namespace PillarResource;

[ExtendObjectType("Query")]
public class PillarQuery : IPillarQuery
{
    IPillarService _pillarService;

    public PillarQuery(IPillarService courseService)
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
