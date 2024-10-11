public class Mutation
{
    private readonly ICourseMutation _courseMutation;
    private readonly IPillarMutation _pillarMutation;

    public Mutation(ICourseMutation courseMutation, IPillarMutation pillarMutation)
    {
        _courseMutation = courseMutation;
        _pillarMutation = pillarMutation;
    }

    public ICourseMutation Course => _courseMutation;
    public IPillarMutation Pillar => _pillarMutation;
}
