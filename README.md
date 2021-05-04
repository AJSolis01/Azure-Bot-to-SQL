# Deployment of Azure Web App Bot Connected to Azure SQL Server


This template allows you to deploy a Echo Bot using C# template and creates a Azure SQL Server with pre-defined SQL table. This template sets the messaging scale set to F0 with 10K premium messages. The C# Echo Bot will reach out to the SQL Server via a connection string that is associated in the EchoBot.cs file in the code. Change the code to match your SQL Server connection string.

Data Flow:
![Data-Diagram](https://user-images.githubusercontent.com/57882033/116953794-2a34bc80-ac5c-11eb-8c38-bc888731c070.jpeg)

What Services Are Used:

5 Pillars of the Azure Well Architected Framework:

Future Revisions:


[![Deploy To Azure](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazure.svg?sanitize=true)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAJSolis01%2FAzure-Bot-to-SQL%2Fmain%2Fazuredeploytemplate.json)  


[![Visualize](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/visualizebutton.svg?sanitize=true)](http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-quickstart-templates%2Fmaster%2F201-vmss-linux-jumpbox%2Fazuredeploy.json)
