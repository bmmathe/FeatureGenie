namespace featuregenie.client
{
    public interface IFeatureManager
    {
        bool IsFeatureEnabled(int applicationId, string featureName);
    }
}
