namespace PillarResource;

[ExtendObjectType("Query")]
public class PillarQuery : IPillarQuery
{
    public async Task<Pillar> GetPillar(Guid id, [Service] IPillarService pillarService)
    {
        return await pillarService.GetPillarByIdAsync(id);
    }

    public async Task<List<Pillar>> GetPillars([Service] IPillarService pillarService)
    {
        return await pillarService.GetPillarsAsync();
    }
}
