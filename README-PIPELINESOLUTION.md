Build starts from the azure-pipelines.yml.
	Currently configured to build and deploy AccuWeather Solution
	Process configured to trigger on master , release or feature branches
	Invokes build-stage.yml for performing the build
	Invokes deployment-stage.yml for performing the deployment to Development and Production

Build starts from build-stage.yml 
	Restores the solution and performs build of the solution
	Runs tests against the test project in the solution
	Publish the build output to a staged artifactory

Deployment Starts from deployment-stage.yml
	Currently configured to deploy to two stages DEVELOPMENT & PRODUCTION
	Deployment to DEVELOPMENT is preliminary followed by a PRODUCTION environment
	Downloads the build output from the staged artifactory (from the build process) and deploys to Azure via Azure Resource [https://accweatherbradydev.azurewebsites.net]
	Downloads the build output from the staged artifactory (from the build process) and deploys to Azure via Azure Resource [https://accweatherbrady.azurewebsites.net]



	