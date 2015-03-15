# Feature Genie
An easy to implement feature manager to enable dark deployments of features in progress.

To get started follow these steps:
1) Run the database_init.sql script on an existing database. This will create a new schema called genie that is used by the web API.
2) Install the Feature Genie Web API in IIS.  You will have to do this manually for now.  I suggest cloning the solution and publish using Visual Studio.
3) Add the FeatureGenie.Client library to your solution.  This provides the classes you will use to interact with the Web API.  
4) Update your config file to set the Feature Genie Web API URL. The appSetting should look like this: <add key="FeatureGenieURL" value="https://featuregenie.domain.com" />
5) Add the conditions to your project.  

FeatureGenie.IsFeatureEnabled("NewCheckoutPage");

Although IsFeatureEnabled accepts a string I suggest creating a class with constants for your features.  This way when you decide you want to remove a feature flag because the feature will always be enabled you can use the IDE to find all references.
