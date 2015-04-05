namespace featuregenie.client
{
    public interface IFeatureManager
    {
        bool IsFeatureEnabled(string name);
    }
}
