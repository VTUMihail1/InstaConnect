# InstaConnect API

## About The Project

InstaConnect is a robust REST API that empowers developers to seamlessly integrate and amplify their applications with the dynamic world of social media. With its intuitive endpoints and comprehensive features, InstaConnect simplifies the process of connecting to popular social platforms, enabling you to create, share, and engage with user-generated content effortlessly. Elevate your app's social capabilities today with InstaConnect!

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Built With

* [![ASP.NET Core][AspNetCoreBadge]][AspNetCoreUrl]
* [![Entity Framework Core][EfCoreBadge]][EfCoreUrl]
* [![MySQL][MysqlBadge]][MysqlUrl]
* [![SignalR][SignalRBadge]][SignalRUrl]
* [![AutoMapper][AutoMapperBadge]][AutoMapperUrl]

[AspNetCoreBadge]: https://img.shields.io/badge/ASP.NET%20Core-blue.svg
[AspNetCoreUrl]: https://dotnet.microsoft.com/apps/aspnet

[EfCoreBadge]: https://img.shields.io/badge/EF%20Core-orange.svg
[EfCoreUrl]: https://docs.microsoft.com/en-us/ef/core/

[MysqlBadge]: https://img.shields.io/badge/MySQL-blue.svg
[MysqlUrl]: https://www.mysql.com/

[SignalRBadge]: https://img.shields.io/badge/SignalR-purple.svg
[SignalRUrl]: https://dotnet.microsoft.com/apps/aspnet/signalr

[AutoMapperBadge]: https://img.shields.io/badge/AutoMapper-green.svg
[AutoMapperUrl]: https://automapper.org/

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Getting Started

### Prerequisites

#### .NET SDK 7.0 Installation

- **What You Need**:
   - Ensure you have the .NET SDK 7.0 installed on your machine.
- **Installation Link**: [Download .NET SDK](https://dotnet.microsoft.com/download)

#### SendGrid SendEmail Key Setup

- **What You Need**: 
   - A SendGrid account.
   - An API key for sending emails.
- **Installation Link**: [SendGrid Signup](https://sendgrid.com/)

#### MySQL Setup

- **What You Need**:
   - MySQL server installed on your machine.
- **Installation Link**: [Download MySQL](https://www.mysql.com/downloads/)

### Installation

#### Clone the project

Open your terminal or command prompt and run the following command to clone the project:
```bash
  git clone https://github.com/VTUMihail1/InstaConnect.git
```

#### Go to the main branch

Navigate to the cloned repository's directory:
```bash
  cd InstaConnect
```

#### Build the app

Build the project using the dotnet build command:
```bash
  dotnet build
```

#### Install dependencies

Restore the project dependencies using the following command:
```bash
  dotnet restore
```

#### Set user secrets

Add all the user secrets to your liking 
```bash
  dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Your_Connection_String_Here"   
  dotnet user-secrets set "TokenOptions:Issuer" "Your_Issuer_Here"   
  dotnet user-secrets set "TokenOptions:Audience" "Your_Audience_Here"   
  dotnet user-secrets set "TokenOptions:SecurityKey" "Your_Security_Key_Here"   
  dotnet user-secrets set "TokenOptions:AccessTokenLifetimeSeconds" "Your_Access-Token-Lifetime"   
  dotnet user-secrets set "TokenOptions:UserTokenLifetimeSeconds" "Your_User-Token-Lifetime"   
  dotnet user-secrets set "EmailOptions:APIKey" "Your_Email_API_Key_Here"   
  dotnet user-secrets set "EmailOptions:Sender" "Your_Email_Sender_Here"   
  dotnet user-secrets set "EmailOptions:ConfirmEmailEndpoint" "Your_Confirm_Email_Endpoint_Here"   
  dotnet user-secrets set "EmailOptions:ResetPasswordEndpoint" "Your_Reset_Password_Endpoint_Here"   
  dotnet user-secrets set "AdminOptions:Email" "Your_Admin_Email_Here"   
  dotnet user-secrets set "AdminOptions:Password" "Your_Admin_Password_Here"   
```

#### Start the app

Finally, start the InstaConnect API application:
```bash
  dotnet run --project InstaConnect.Presentation.API   
```


<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Usage

To interact with the InstaConnect API and explore available endpoints, we provide detailed documentation using Swagger.

### Swagger Documentation

You can access the Swagger documentation for InstaConnect by navigating to the following URL in your web browser after starting the application:

- [Swagger Documentation](https://localhost:7038/swagger/index.html)

Here, you will find a user-friendly interface that allows you to:

- **Browse and search** for available API endpoints.
- View detailed **descriptions** and **usage** instructions for each endpoint.
- **Execute API requests directly** from the documentation to test the endpoints.

Swagger makes it easy to understand and interact with the API, making your integration efforts smooth and efficient.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See - [InstaConnect License](https://github.com/VTUMihail1/InstaConnect/blob/master/LICENSE.txt) for more information. Feel free to use and modify the code as needed for your own purposes.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Contact

[LinkedIn](https://www.linkedin.com/in/mihail-nikolov-a24b29255/) | [LeetCode](https://leetcode.com/VTUMihail/) | [GitHub Repository](https://github.com/VTUMihail1/InstaConnect.git)

<p align="right">(<a href="#readme-top">back to top</a>)</p>
