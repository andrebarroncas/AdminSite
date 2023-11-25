# AdminSite
Example of API .Net Core 6, DDD, SQL Server, XUnit


<details open="open">
  <summary>Conteudo</summary>
  <ol>
    <li>
      <a href="#sobre-o-projeto">About the Project</a>
      <ul>
        <li><a href="#build-status">Build Status</a></li>
        <li><a href="#built-with">Built With</a></li>
        <li><a href="#features">Features</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#Requirements">Requirements</a></li>
        <li><a href="#v">Setup</a></li>
      </ul>
    </li>
    <li><a href="#licence">Licence</a></li>
  </ol>
</details>

## About th Project

This project is a .NET Core 6 API built with Domain Driven Design. It aims to share programming knowledge and elevate developers' skills. Despite its simplicity, it covers SOLID principles and comprehensive unit tests using Postman collections.

The API enables users to register and manage kitchen recipes with titles, ingredients, and preparation methods. Recipes are categorized for easy filtering (breakfast, lunch, dessert, dinner) and are editable or deletable.

An interesting feature allows users to share recipes via WebSocket. Users generate QR Codes for connection, enabling the mutual viewing of recipes between connected users.


### Build Status

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=MeuLivroDeReceitas&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=MeuLivroDeReceitas)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=MeuLivroDeReceitas&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=MeuLivroDeReceitas)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=MeuLivroDeReceitas&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=MeuLivroDeReceitas)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=MeuLivroDeReceitas&metric=coverage)](https://sonarcloud.io/summary/new_code?id=MeuLivroDeReceitas)

### Built With

![windows-shield] ![ubuntu-shield] ![figma-shield] ![visualstudio-shield] ![netcore-shield] ![swagger-shield] ![postman-shield] 

### Features

- Register user;
- Create my own recipes;
- Add category to recipes to make filtering easier;
- Share my recipes with friends;
- Add friends using WebSocket to accept real-time connection.

And more.

## Getting Started

### Requirements

* Visual Studio 2022+

* SQL Server

### Setup

1. Clone the repository
    ```sh
    git clone https://github.com/andrebarroncas/AdminSite.git
    ```
2. Fill in the information in the `appsettings.Development.json` file.
3. Run the Web API
4. Great test :)


## Roadmap


## Licence

Feel free to use this project to study and learn. You are not permitted to use it for distribution or commercialization.

+

<!-- Shields build with -->
[windows-shield]: https://img.shields.io/badge/Windows-00599E?style=for-the-badge&logo=windows&logoColor=white

[ubuntu-shield]: https://img.shields.io/badge/Ubuntu-93300A?style=for-the-badge&logo=ubuntu&logoColor=white

[figma-shield]: https://img.shields.io/badge/Figma-353535?style=for-the-badge&logo=figma&logoColor=white

[visualstudio-shield]: https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white

[netcore-shield]: https://img.shields.io/badge/.NET_%20_Core_6.0-5C2D91?style=for-the-badge&logo=.net&logoColor=white

[swagger-shield]: https://img.shields.io/badge/Swagger-205E3B?style=for-the-badge&logo=swagger&logoColor=white

[postman-shield]: https://img.shields.io/badge/Postman-AA2E00?style=for-the-badge&logo=postman&logoColor=white

[buy-me-book]: https://img.shields.io/badge/-buy_me_a_book-gray?logo=buy-me-a-coffee&style=for-the-badge

<!-- Shields about the project -->
[maintained-shield]: https://img.shields.io/badge/Maintained%3F-yes-314100.svg?style=for-the-badge

[stars-shield]: https://img.shields.io/github/stars/andrebarroncas/Timerom.svg?style=for-the-badge&color=03146F

[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555

<!-- Urls -->
[linkedin-url]: https://www.linkedin.com/in/andrebarroncas/
