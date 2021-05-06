# Generates a Random Value
$Random=(New-Guid).ToString().Substring(0,8)

# Variables
$ResourceGroup="AzureCloudBot"
$AppName="azurebotapp"
$Location="East US"
$ServerName="AzureCloudSQL"
$Username="Username"
$Password="Welcome2021!"
$SqlServerPassword=New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $Username,(ConvertTo-SecureString -String $Password -AsPlainText -Force)

# Create a Resource Group
New-AzResourceGroup -Name $ResourceGroup -Location $Location

# Create an App Service Plan
New-AzAppservicePlan -Name AzureBotPlan -ResourceGroupName $ResourceGroup -Location $Location -Tier Free

# Create a Web App in the App Service Plan
New-AzBotService -ResourceGroupName $resourceGroup -AppServicePlan AzureBotPlan  -Name $BotName -ApplicationId $ApplicationId -Location $location -Sku F0 -Description "EchoBot" -Webapp

# Create a SQL Database Server
New-AzSQLServer -ServerName $ServerName -Location $Location -SqlAdministratorCredentials $SqlServerPassword -ResourceGroupName $ResourceGroup

# Create SQL Database in SQL Database Server
New-AzSQLDatabase -ServerName $ServerName -DatabaseName cloudcomputedb -ResourceGroupName $ResourceGroup

# Assign Connection String to Connection String 
Set-AzWebApp -ConnectionStrings @{ MyConnectionString = @{ Type="SQLAzure"; Value ="Server=tcp:$ServerName.database.windows.net;Database=MySampleDatabase;User ID=$Username@$ServerName;Password=$password;Trusted_Connection=False;Encrypt=True;" } } -Name $AppName -ResourceGroupName $ResourceGroup
