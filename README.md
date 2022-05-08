# KPMG Test - Solution
This file describes the solution for the three challenges as part of KPMG Test. 

## Challenge 1
A 3-tier environment is a common setup. Use a tool of your choosing/familiarity create these resources. Please remember we will not be judged on the outcome but more focusing on the approach, style and reproducibility.

### Key Considerations
- A 3 tier application is created with a webapp, a WebAPI and a Database repository. 
- In terms of infrastructure, application will have 3 components, 2 Websites (1 each for webapp and WebAPI) and 1 SQL Database
- Two new workflow has been added that builds and then deploys the webapp and WebAPI solution respectively on Azure.
- Azure App services have been used for hosting the .net core websites An ARM template has been added to the solution to deploy the Azure App Service. 
- Azure SQL is used for database and an ARM template has been used for deployment. 
- As part of the CD, 4 environments will be provisioned i.e. Dev, Test, Uat and Prod. 
- App Service staging slots have been used to ensure zero down time. 
- GitHub flow has been used as the branching strategy. GitHub branch policies have been configured accordingly. 
- Any secret value has been stored as part of GitHub secrets. 

### Branch Policies
- Main is locked for direct commit. Any commit to main can only be done via a PR.
- All checks in PR must pass successfully for merge to main. 

### Configuration Management
- All secure configurations have been stored as part of GitHub secrets. 
- 4 Environments have been defined and corresponding configurations have been defined as environment scoped secrets. 
- Azure service principal is used for Infra and App deployment and is stored as a secure configuration. 

### CI Features
CI Consists of a combination of actions as explained below - 
- As part of the CI, workflow will build the .net core solution using MSBuild by restoring the nugget packages first and then running the build. 
- Artifacts will be published as part of CI Job which then can be consumed by CD Jobs. 
- On every main commit, a new tag and a release will be added in GitHub main repo.

### CD Features
#### IaC
- Azure Web App ARM template is defined as IaC. 
- Azure SQL database ARM template is defined as IaC
- Azure App service Plan and Azure SQL Server are deployed manually in order to limit the scope of this solution. 

#### Environments
- 4 environments are provisioned as part of CD jobs i.e. Dev, Test, Uat and Prod. Except Dev, all environments will require approval. 
- Dev and Test will be deployed from Feature branches to run automated tests as well as to ensure fully tested code is moved to main. These environments will also be deployed as part of PR checks.
- Named environments need not be persisted and can be deleted if only Automated testing is being done or can be deleted/created via a scheduled job for manual testing. This has been kept out of scope as part of this solution. 
- All environments will be deployed with main branch. 

## Challenge 2
Summary
We need to write code that will query the meta data of an instance within aws and provide a json formatted output. The choice of language and implementation is up to you.

Bonus Points
The code allows for a particular data key to be retrieved individually

### Key Considerations
- As part of the challenge it says, we can use Azure or GCP as well, so I have used Azure VM Instance to get the metadata.
- A PowerShell script has been written to get either all the metadata or the specified key.

### How to run PowerShell script
Below samples can be used to run the script 
- GetAzure-InstanceMetaData.ps1 //Returns all metadata
- GetAzure-InstanceMetaData.ps1 network.interface.ipv4 //Returns specified property value
- GetAzure-InstanceMetaData.ps1 compute //Returns specified property value
- GetAzure-InstanceMetaData.ps1 compute.version //Returns specified property value

## Challenge 3 
Nested object Challenge

### Solution
- A function has been written which takes two input parameters - strObj and key. 
- This function  then calculates the key value and returns as json. 
- Please refer to KPMG.Interview.TaskThree.csproj for further details. 
- A console app has been created on top of it to run this function - KPMG.Interview.TaskThree.ConsoleApp.csproj
- Also, some unit tests have been written to test this function - KPMG.Interview.Tests.csproj
