# Feature Genie
An easy to implement feature and configuration settings manager to enable production deployments of features in progress as well as changing configuration settings real-time.

Installing the database

1. Create a database for FeatureGenie.  I called mine FeatureGenieDB
2. Open the solution and locate the FeatureGenieDbDeploy project.  Modify the connection string named FeatureGenieDeploy to point to your database. 
3. Run the FeatureGenieDeploy project.  This uses DbUp to install the database.  DbUp tracks which scripts have been run on the database so you can run this program many times without executing the same script twice.

Configuring FeatureGenie
 
1. Install the Feature Genie Web API in IIS.  You will have to do this manually for now.  I suggest cloning the solution and publish using Visual Studio.
2. Add the FeatureGenie.Client library to your solution.  This provides the classes you will use to interact with the Web API.  
3. Update your config file to set the Feature Genie Web API URL. The appSetting should look like this: `<add key="FeatureGenieURL" value="https://featuregenie.domain.com" />`
4. Include the client library in your solution.  The client will allow you to access features and configuration settings.  

```C#
FeatureGenie.IsFeatureEnabled("NewCheckoutPage");
FeatureGenie.AppSettings("ThirdPartyServiceUrl");
```

Although IsFeatureEnabled accepts a string I suggest creating a class with constants for your features.  This way when you decide you want to remove a feature flag because the feature will always be enabled you can use the IDE to find all references.

I also suggest caching your configuration settings and reloading them on a schedule.