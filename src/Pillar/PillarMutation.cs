using PillarResource;

[ExtendObjectType("Mutation")]
public class PillarMutation : IPillarMutation
{
    public async Task<Pillar> AddPillar(
        AddPillarInput input,
        [Service] IPillarService pillarService
    )
    {
        return await pillarService.AddPIllarAsync(input);
    }

    public async Task<Pillar> UpdatePillar(
        Guid id,
        UpdatePillarInput updatePillarInput,
        [Service] IPillarService pillarService
    )
    {
        return await pillarService.UpdatePillarAsync(id, updatePillarInput);
    }

    public async Task DeletePillar(Guid id, [Service] IPillarService pillarService)
    {
        await pillarService.DeletePillarAsync(id);
    }
}
