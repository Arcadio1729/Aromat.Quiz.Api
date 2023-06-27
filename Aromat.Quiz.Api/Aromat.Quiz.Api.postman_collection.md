| | | | | | | | | | | |
|-|-|-|-|-|-|-|-|-|-|-|
|info| | | |item| | | | | | |
|_postman_id|name|schema|_exporter_id|name|item| | | | | |
| | | | | |name|request| | | |response|
| | | | | | |method|header|url|description| |
|c93dffd3-0d87-4324-b7b5-66fadd6e9555|Aromat.Quiz.Api|https://schema.getpostman.com/json/collection/v2.0.0/collection.json|20989323|User Actions|Register User|POST| |https://aromat-quiz-api.azurewebsites.net/api/account/register|## Action Description  Creates new user.  ## Required Body Fields  ``` json { "lastName": "string", "firstName": "string", "email": "string", "password": "string", "confirmPassword": "string", "roleId": 0 }  ```| |
| | | | | |Login User|POST| |https://aromat-quiz-api.azurewebsites.net/api/account/login|## Action Description  Login and get temporary token in response.  ## Required Body Fields  ``` json { "email": "string", "password": "string" }  ```| |
| | | | | |Create User|POST| |https://aromat-quiz-api.azurewebsites.net/api/account/users/add-user|## Action Description  Creates user with given data (for admin purposes).  ## Required Body Fields  ``` json {   "firstName": "string",   "lastName": "string",   "email": "string",   "role": "string" }  ```| |
| | | | | |Create Role|POST| |https://aromat-quiz-api.azurewebsites.net/api/account/roles/add-role/{roleName}|## Action Description  Creates new role. (Only one parameter)  ## Required Route Parameter  roleName| |
| | | | | |Get Roles|GET| |https://aromat-quiz-api.azurewebsites.net/api/account/roles|## Action Description  Returns roles that can be assigned to user.  ## Required Body Fields  None| |
| | | | | |Get Users|GET| | |## Action Description  Returns all users from system.  ## Required Body Fields  None| |
| | | | | |Update User|PUT| |https://aromat-quiz-api.azurewebsites.net/api/account/users/update-user|## Action Description  Update user data having id.  ## Required Body Fields  ``` json {   "id": 0,   "firstName": "string",   "lastName": "string",   "email": "string",   "role": "string" }  ```| |
