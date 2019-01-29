# multiplication-tables-azure
A static webpage hosted in Github Pages with Ajax calls linking to Azure.

The static webpage index.html links to three Azure resources which are each opened in a separate project:

1. A collection of Azure Javascript functions opened using Visual Studio Code from folder AzureJsMultiTableJsFuncs.
2. A collection of Azure C-sharp functions opened using Visual Studio Community Edition 2017 from a solution file in folder AzureMultiTableCsFuncs.
3. An Azure C-sharp Wcf service opened using Visual Studio Community Edition 2017 from a solution file in folder AzureMultiTablesWcfSvc01.

To enable the Ajax calls, CORS settings must be modified within Azure. All the Js and Cs functions are placed in a single Function App in Azure from which the CORS settings for allowed origins points to our Github Pages address. This can be set manually.

The CORS settings for the app service containing our WCF service can be set in powershell using the command below. The resource group param, app name param and allowed origin website param must be modified accordingly: 

az resource update --name web --resource-group <myResourceGroup> --namespace Microsoft.Web --resource-type config --parent sites/<app_name> --set properties.cors.allowedOrigins="['http://localhost:5000']" --api-version 2015-06-01
  
