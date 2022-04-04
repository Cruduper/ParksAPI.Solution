# Parks API

---

## 🌐 About the Project

### 📖 Description

C# API application was a weekly project in my programming bootcamp, and includes code-first migration for database schema creation in MySQL. The API returns information about Parks and includes a naive implementation of search functionality using URL query strings. For the project it was suggested that we try one of five "further exploration" topics: CORS, pagination, Swagger, Versioning, and jwt token-based Authentication. I decided to spend some extra time and try to implement all of these into my API for educational purposes (although currently token-based Authentication is still a work in progress).   

### 🦠 Known Bugs OR Issues

- No known bugs 

### 🛠 Built With

- [Visual Studio Code](https://code.visualstudio.com/)
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
- [MySQL 8.0.20 for Linux](https://dev.mysql.com/)
- [Entity Framework Core 2.2.6](https://docs.microsoft.com/en-us/ef/core/)
- [Swagger - NSwag 13.3.0](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1&tabs=visual-studio)
- [Postman](postman.com)

<!-- ### 🔍 Preview -->

---

## 🏁 Getting Started

### 📋 Prerequisites

#### Install .NET Core

- On macOS Mojave or later
  - [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) to download the .NET Core SDK from Microsoft Corp for macOS.
- On Windows 10 x64 or later
  - [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer) to download the 64-bit .NET Core SDK from Microsoft Corp for Windows.

#### Install dotnet script

Enter the command `dotnet tool install -g dotnet-script` in Terminal for macOS or PowerShell for Windows.

#### Install MySQL Workbench

[Download and install the appropriate version of MySQL Workbench](https://dev.mysql.com/downloads/workbench/).

#### Install Postman

(Optional) [Download and install Postman](https://www.postman.com/downloads/).

#### Code Editor

To view or edit the code, you will need an code editor or text editor. The popular open-source choices for an code editor are Atom and VisualStudio Code.

1. Code Editor Download:
   - Option 1: [Atom](https://nodejs.org/en/)
   - Option 2: [VisualStudio Code](https://www.npmjs.com/)
2. Click the download most applicable to your OS and system.
3. Wait for download to complete, then install -- Windows will run the setup exe and macOS will drag and drop into applications.
4. Optionally, create a [GitHub Account](https://github.com)

### ⚙️ Setup and Use

#### Cloning

1. Click 'Code' to reveal the HTTPS url ending with .git and the 'Download ZIP' option.
2. Open up your system Terminal or GitBash, navigate to your desktop with the command: `cd Desktop`, or whichever location suits you best.
3. Clone the repository to your desktop: `$ git clone https://github.com/Cruduper/ParksAPI.Solution.git`
4. Run the command `cd parks` to enter into the project directory.
5. View or Edit:
   - Code Editor - Run the command `atom .` or `code .` to open the project in Atom or VisualStudio Code respectively for review and editing.
   - Text Editor - Open by double clicking on any of the files to open in a text editor.

#### Download

1. Click 'Code' to reveal the HTTPS url ending with .git and the 'Download ZIP' option.
2. Click 'Download ZIP' and unextract.
3. Open by double clicking on any of the files to open in a text editor.

#### AppSettings

1. Create a new file in the message-board-api/MessageBoard directory named `appsettings.json`
2. Add in the following code snippet to the new appsettings.json file:

```
{
  "Logging": {
      "LogLevel": {
      "Default": "Warning"
      }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=parks;uid=[YOUR_USER_ID_HERE];pwd=[YOUR_PASSWORD_HERE];"
  }
}
```

3. Change the server, port, and user id as necessary. Replace '\[YOUR_PASSWORD_HERE\]' with relevant MySQL password (set at installation of MySQL), same goes for \[YOUR_USER_ID_HERE\], although you may have simply set your user id to "root" during installation.

#### Database

1. Navigate to message-board-api/MessageBoard directory using the MacOS Terminal or Windows Powershell (e.g. `cd Desktop/message-board-api/MessageBoard`).
2. Run the command `dotnet ef database update` to generate the database through Entity Framework Core.
3. (Optional) To update the database with any changes to the code, run the command `dotnet ef migrations add <MigrationsName>` which will use Entity Framework Core's code-first principle to generate a database update. After, run the previous command `dotnet ef database update` to update the database.

#### Launch the API

1. Navigate to message-board-api/MessageBoard directory using the MacOS Terminal or Windows Powershell (e.g. `cd Desktop/message-board-api/MessageBoard`).
2. Run the command `dotnet run` to have access to the API in Postman or browser.

---

## 🛰️ API Documentation

Explore the API endpoints in Postman or a browser. You will not be able to utilize authentication in a browser.

### Using Swagger Documentation

To explore the MessageBoard API with NSwag, launch the project using `dotnet run` with the Terminal or Powershell, and input the following URL into your browser: `http://localhost:5000/swagger`

#### Example Query

```
https://localhost:5000/api/messages/?author=Ryan+Spencer
```

..........................................................................................

### Message Endpoints

Access specific information on message board posts from various authors and categories

#### HTTP Request

```
GET /api/1.0/Parks
POST /api/1.0/Parks
GET /api/1.0/Parks/{id}
PUT /api/1.0/Parks/{id}
DELETE /api/1.0/Parks/{id}
```

#### Path Parameters (must be exact match)

| Parameter |  Type  | Default | Required | Description                                                    |
| :-------: | :----: | :-----: | :------: | -------------------------------------------------------------- |
|   Name    | string |  none   |   true   | Return matches by specific park's name               |
|  City   | string |  none   |   true   | Return matches by specific city that park is located in          |
|   State  | string |  none   |   true   | Return matches by specific state that park is located in |
|   Size   | int |  none   |   true   | Return matches of parks with larger size (in square miles) than given query number |

#### Example Query

```
https://localhost:5000/api/messages/?city=Portland&size=246
```

#### Sample JSON Response

```
{
    "parkId": 9,
    "name": "Banks Vernonia Trail",
    "city": "Portland",
    "state": "OR",
    "swimming": false,
    "hiking": true,
    "size": 2719

    "parkId": 12,
    "name": "Bald Peak",
    "city": "Portland",
    "state": "OR",
    "swimming": false,
    "hiking": true,
    "size": 246
}

```

---

### 🤝 Contributors

 [Eric Crudup](https://github.com/Cruduper) 

---

### ⚖️ License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). Copyright (C) 2022 Eric Crudup. All Rights Reserved.

```
MIT License
Copyright (c) 2021 Eric Crudup.
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

---

<center><a href="#">Return to Top</a></center>