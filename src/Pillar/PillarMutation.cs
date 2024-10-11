using PillarResource;

[ExtendObjectType("Mutation")]
public class PillarMutation : IPillarMutation
{
    private readonly IPillarService _pillarService;

    public PillarMutation(IPillarService PillarService)
    {
        _pillarService = PillarService;
    }

    public async Task<Pillar> AddPillar(AddPillarInput addPillarInput)
    {
        return await _pillarService.AddPIllarAsync(addPillarInput);
    }

    public async Task<Pillar> UpdatePillar(Guid id, UpdatePillarInput updatePillarInput)
    {
        return await _pillarService.UpdatePillarAsync(id, updatePillarInput);
    }

    public async Task DeletePillar(Guid id)
    {
        await _pillarService.DeletePillarAsync(id);
    }
}
