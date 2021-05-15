# Deployment of Azure Web App Bot Connected to Azure SQL Server


This template allows you to deploy a Echo Bot using C# template and creates a Azure SQL Server with pre-defined SQL table. This template sets the messaging scale set to F0 with 10K premium messages. The C# Echo Bot will reach out to the SQL Server via a connection string that is associated in the EchoBot.cs file in the code. Change the code to match your SQL Server connection string.

## Visio Diagram:
![Visio Diagram](https://user-images.githubusercontent.com/57882033/116955082-9533c280-ac5f-11eb-9eeb-b7520e39b980.jpeg)



## Data Flow:
![Data-Diagram](https://user-images.githubusercontent.com/57882033/116953794-2a34bc80-ac5c-11eb-8c38-bc888731c070.jpeg)

## What Services Are Used:
 + **Web App Bot**
 + **SQL Server**
 + **App Service**

## Microsoft Azure Well-Architected Framework:
 + **Cost Optimization**
   + For this Cloud Service hosted in Azure, The Azure Web App bot is running as a F0 Tier meaning that all messages that are sent into the Bot Service are free up to 10,000 messages. The SQL Server that is used to retrieve information from is running at 1 GB of storage. This is not the lowest amount of storage that the SQL Server can go. If anyone were to use this, it can be changed out to meet their needs. 1 GB of storage allows for much data to be stored in this drive and runs at a low cost.
 + **Operational Excellence**
   + To monitor these cloud resources is very simple, there is no VM or anything that is needed to login to view if the operating system is failing. The SQL Server is the only server that is being ran for these cloud resources. The data is stored in one place and that is the SQL Server, it can be easily accessed by logging into the SQL directly from the Azure Portal, or by connecting the SQL Server through SSMS or Visual Studio. To view the overall health of the Bot, users must access the App Service. From there they can view any important logs, data, or alerts that have appeared for the Web App Bot. 
 + **Performance Efficiency**
   + Since this application is all hosted on Azure, users can find it very easy to scale up and scale out if they need to. For the SQL Server, users can simply scale up by adding more additional storage to SQL Server. If users would like to add more SQL Servers to the application, it is a matter of creating the SQL Server and then adding it to the connection strings. Scaling up for the Web App Bot means that the user can change the Tier of Bot from F0 to S1 Standard. This will be $.50 every 1,000 free messages and get a 99.9% premium SLA for the S1 Tier. This application can be scaled up or down and scaled out to whatever it needs to be.
 + **Reliability**
   + The Azure SQL Database offers a built-in data replication to both within a region and across regions. Given that the reliability that the data will not be lost due to corrupt SQL Server or data loss. The data will be backed up in case of an emergency and will be there without worry. The source code for this web app bot can be downloaded in case the bot somehow becomes unusable, simply a new bot can be deployed, and users can upload the code from visual studio code. 
 + **Security**
   + The SQL Server for this cloud resource has a built-in firewall that only allows users who know the login through the azure portal or a trusted IP address. IN the firewall for the SQL Server, if a person is needing access to the SQL Server from outside the azure portal, they must be granted access through that firewall. The IP address will need to be added in the firewall rules for that person to be granted access. The web app bot can only be used if the secret key is place in the iframe html tag. This secret key is a long complex 55 character using letters, numbers, and special characters. Making this a complex secret key for security reasons. 

## Future Revisions:
 + Have a return for a tracking number that is not valid.
 + Include a link that takes customer to carrier tracking page.
 + Have the Bot communicate more frequently, only responds to input.
 + Include an image of carrier when receiving response.

## How to Deploy: 
 + Download the zip file from Github
 + Unzip the file to a folder
 + Run the Azure CLI script automationscript.ps1
 + Once the script is done running, you will need to add data into the database
 + Login to your azure portal and navigate 
 + Enter the code below to enter data into the database
 + +Once the data has been entered. Enter the test Bot and enter a tracking number

 
`
INSERT INTO [dbo].[Tracking] VALUES (1, 'Austin', 'Solis', 'Fort Wayne', 'Indiana')
INSERT INTO [dbo].[Tracking] VALUES (2, 'User', 'Test1', 'Chicago', 'Illinois')
INSERT INTO [dbo].[Tracking] VALUES (3, 'User', 'Test2', 'Denver', 'Colorado')
`
