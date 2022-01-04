Build starts from the .github/workflows/azure-webapps-dotnet-core.yml.
	Currently configured to build and deploy AccuWeather Solution
	Process configured to trigger on master and feature branches
	Performs the Project build and tests 
	Performing the deployment to Development and Production

Build has the following attributes 
	Restores the solution and performs build of the solution
	Runs tests against the test project in the solution
	Publish the build output to a staged artifactory

Deployment has following attributes
	Currently configured to deploy to two stages DEVELOPMENT & PRODUCTION
	Deployment to DEVELOPMENT is preliminary followed by a PRODUCTION environment
	Downloads the build output from the staged artifactory (from the build process) and deploys to Azure via Azure Resource [https://accweatherbradydev.azurewebsites.net]
	Downloads the build output from the staged artifactory (from the build process) and deploys to Azure via Azure Resource [https://accweatherbrady.azurewebsites.net]



	
