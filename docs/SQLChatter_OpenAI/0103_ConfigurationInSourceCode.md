---
title: 3. Configuration in Source Code
layout: home
nav_order: 3
parent: 'SQL Chatter Project (Azure OpenAI Version)'
---

## 3. Configuration in Source Code:

To configure your Azure OpenAI and SQL Database settings in your source code, follow these steps:

* Go to the source code opened in Visual Studio Code or Visual Studio 2022.

* Open the **"ghcopilotdemo\OpenAISQLChatter_WebApp\appsettings.json"** file, find the "AzureOpenAI" object:

   ```json
     "AzureOpenAI": {
       "Endpoint": "https://******.openai.azure.com/",
       "Key": "************",
       "DeploymentName": "******"
     },
   ```

* Update above code in **"appsettings.json"** file with the following detailed information from Azure Portal:

  * In the Azure Portal, go to the created Azure Open AI service named **"AIChatter"**.
  * Under the "Resource Management" menu in the left, navigate to the "Keys and Endpoint" section.
  * Here, you will find the keys (KEY 1 and KEY 2). Copy one of these keys and use for ```Key``` value in the json part.
  * You will also find the "Endpoint URL" here. It typically looks like ```https://<your-resource-name>.openai.azure.com/```. Copy this "Endpoint address" and use for ```Endpoint``` value in the json part. (In this exercise, your "Endpoint" will be ```https://aichatter.openai.azure.com/```).
  * Under the "Resource Management" menu in the left, navigate to the "Model deployments" section and click on the "Manage Deployments" button.
  * Find your Model Deployment and copy its name. (You created **"AIChatterModel"** before, so copy this name and use for ```DeploymentName``` value in the json part.

* In the **"appsettings.json"** file, find the "SQL" object:

   ```json
    "SQL": {
       "Server": "********.database.windows.net",
       "Database": "********",
       "User": "********",
       "Password": "********"
     }
   ```
  
* Update above code in **"appsettings.json"** file with the following detailed information from Azure Portal:

  * In the Azure Portal, go to the SQL Databases and find your created database named **"AIChatterDB "**.
  * Under the "Overview" menu in the left, copy the "Server name" and use for ```Server``` value in the json part. (In this exercise, your "Server name" will be ```aichatterserver.database.windows.net```).
  * Copy the "Database" name and use for ```Database``` value in the json part. (In this exercise, your "Database name" will be ```AIChatterDB```).
  * For the ```User``` and ```Password``` fields  in the json file, please use the "admin user" and "password" values you created before.

   By following these steps, you will correctly configure the appsettings.json file with your Azure OpenAI and SQL Database details, allowing your application to connect and interact with these services properly.

   Example Updated Configuration in **"appsettings.json"** file:

   ```json
     "AzureOpenAI": {
      "Endpoint": "https://aichatter.openai.azure.com/",
      "Key": "your-key-here",
      "DeploymentName": "AIChatterModel"
    },
     "SQL": {
       "Server": "aichatterserver.database.windows.net",
       "Database": "AIChatterDB",
       "User": "your-admin-user",
       "Password": "your-password"
     }
   ```

&nbsp;
> Please continue to next step: [4. Running the Application](https://241.github.io/ghcopilotdemo/SQLChatter_OpenAI/0104_RunningTheApp.html).