using PillarResource;

public class PillarMutation
{
    private readonly PillarService _pillarService;

    public PillarMutation(PillarService PillarService)
    {
        _pillarService = PillarService;
    }

    public async Task<Pillar> AddPillar(AddPillarInput addPillarInput)
    {
        return await _pillarService.AddPIllarAsync(addPillarInput);
    }

    public async Task<Pillar> updatePillarAsync(Guid id, UpdatePillarInput updatePillarInput)
    {
        return await _pillarService.UpdatePillarAsync(id, updatePillarInput);
    }
}
