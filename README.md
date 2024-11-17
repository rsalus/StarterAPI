# StarterAPI
This repo contains a basic demonstration of CRUD operations using Minimal APIs and EntityFrameWork.

## Getting Started
* Clone the Repo: `git clone https://github.com/rsalus/StarterAPI.git`
* CD to root directory: `cd StarterAPI/`

### Visual Studio Code
* Download C# Dev Kit
* Follow the `Welcome: Open Walkthrough` guide to configure your environment
  * You **must** download the latest .NET SDK.
  * To access the guide: `ctrl+shift+p` then type `Welcome: Open Walkthrough`. Select `Get Started with C# Dev Kit`.
* Open the root directory: `ctrl+k` then `ctrl+o`. Select `StarterAPI` (it should contain the `src/` directory).
* Open Program.cs in the code editor (double-click on it).

### Visual Studio IDE
* Install the .NET 9 SDK with the Visual Studio Installer.
* Open the `.sln` file.
* Open the Program.cs in the code editor.

### Example Code
```
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World!");

app.Run();
```

Run `curl http://localhost:5000` in your terminal to see the result.