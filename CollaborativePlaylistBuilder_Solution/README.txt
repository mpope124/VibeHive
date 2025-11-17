MIDTERM PART 2 

COLLABORATIVE PLAYLIST BUILDER:
- API 
- SignalR
- UI

Notes from Student TROENDLE DEV422 PROF USMAN BELLEVUE COLLEGE FALL 2025

GIT--------------------------------------------------------------------
git init
git remote add origin https://github.com/mpope124/VibeHive.git
git add .
git commit -m "Initial commit for VibeHive assignment"
git branch -M main
git push -u origin main
git push -u origin master

NUGET PACKAGES ---------------------------------------------------------
Install-Package NewtonSoft.Json
Install-Package Microsoft.AspNetCore.SignalR.Client

SCAFFOLDING-------------------------------------------------------------
CollaborativePlaylistBuilder/
│
├── CollaborativePlaylistBuilder.API/
│   ├── Commands/
│   │   AddSongCommand.cs
│   │   VoteSongCommand.cs
│   ├── Controllers/
│   │   PlaylistsController.cs
│   ├── Models/
│   │   Playlist.cs
│   │   Song.cs
│   ├── Program.cs
│   ├── Startup.cs
│   └── CollaborativePlaylistBuilder.API.csproj
│
├── CollaborativePlaylistBuilder.WinForms/
│   ├── Forms/
│   │   MainForm.cs
│   │   InviteCollaboratorsForm.cs
│   ├── Program.cs
│   └── CollaborativePlaylistBuilder.WinForms.csproj
│
└── Shared/
    ├── Interfaces/
    │   ICommand.cs
    └── Shared.csproj


--------------API Endpoints Implemented --------------------------------------

POST /api/playlists → Create playlist
GET /api/playlists → List playlists
PUT /api/playlists/{id}/add → Add song
PUT /api/playlists/{id}/invite → Invite collaborators 
POST /api/playlists/{id}/vote → Vote on song
GET /api/playlists/{id}/rankings → Get rankings

------------------------------------------------------------------------------------
# Collaborative Playlist Builder Solution

## How to Run
1. Open `CollaborativePlaylistBuilder.sln` in Visual Studio.
2. Set `CollaborativePlaylistBuilder.API` as the startup project and run it.
3. Then run `CollaborativePlaylistBuilder.WinForms`.

## NuGet Packages Required
- For API: Microsoft.AspNetCore.App (included by default in ASP.NET Core projects).
- For WinForms: Install Newtonsoft.Json
  - In Package Manager Console: `Install-Package Newtonsoft.Json`

## Notes
- API runs on http://localhost:5000 by default.
- WinForms uses HttpClient to call API endpoints.
------------------------------------------------------------------------------------

# Collaborative Playlist Builder with SignalR

## How to Run
1. Open CollaborativePlaylistBuilder.sln in Visual Studio.
2. Install Newtonsoft.Json in WinForms project.
3. Run API first, then WinForms.

## SignalR Setup
- API exposes a hub at `/playlistHub`.
- WinForms can connect using Microsoft.AspNetCore.SignalR.Client.

### Sample WinForms Client Snippet

using Microsoft.AspNetCore.SignalR.Client;
HubConnection connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5000/playlistHub")
    .Build();

connection.On<int,int,int>("ReceiveVoteUpdate", (playlistId, songId, votes) =>
{
    MessageBox.Show($"Playlist {playlistId}, Song {songId} now has {votes} votes.");
});

await connection.StartAsync();


## Functional Test Example
- POST /api/playlists
- PUT /api/playlists/1/add
- POST /api/playlists/1/vote triggers SignalR broadcast


-------------------------------------------- Operation-------------


+-------------------+        SignalR Hub        +-------------------+
|   WinForms UI     | <-----------------------> |   ASP.NET Core API|
|  Tabs:            |                          |  Endpoints:       |
|  - Music Rental   |                          |  - Playlists CRUD |
|  - Playlist Builder|                          |  - Voting         |
|  - Album Inventory|                          |                   |
+-------------------+                          +-------------------+
        |                                              |
        |                                              |
        |                gRPC                          |
        +----------------------------------------------+
                          Album Inventory Service


C:\Node\GitPort\dev422_fall_midterm\VibeHive\CollaborativePlaylistBuilder_Solution (main -> origin)
λ tree /f
Folder PATH listing for volume Windows
Volume serial number is 50AD-3625
C:.
│   CollaborativePlaylistBuilder.sln
│   CollaborativePlaylistBuilder_PostmanCollection.json
│   GlobalTypes.cs
│   IntegrationDiagram.png
│   README.txt
│
├───CollaborativePlaylistBuilder.API
│   │   CollaborativePlaylistBuilder.API.csproj
│   │   Program.cs
│   │   Startup.cs
│   │
│   ├───bin
│   │   └───Debug
│   │       ├───net6.0
│   │       │       CollaborativePlaylistBuilder.API.deps.json
│   │       │       CollaborativePlaylistBuilder.API.dll
│   │       │       CollaborativePlaylistBuilder.API.exe
│   │       │       CollaborativePlaylistBuilder.API.pdb
│   │       │       CollaborativePlaylistBuilder.API.runtimeconfig.json
│   │       │       CollaborativePlaylistBuilder.API.staticwebassets.endpoints.json
│   │       │       Microsoft.AspNetCore.Connections.Abstractions.dll
│   │       │       Microsoft.AspNetCore.Http.Connections.Client.dll
│   │       │       Microsoft.AspNetCore.Http.Connections.Common.dll
│   │       │       Microsoft.AspNetCore.SignalR.Client.Core.dll
│   │       │       Microsoft.AspNetCore.SignalR.Client.dll
│   │       │       Microsoft.AspNetCore.SignalR.Common.dll
│   │       │       Microsoft.AspNetCore.SignalR.Protocols.Json.dll
│   │       │       Microsoft.Bcl.AsyncInterfaces.dll
│   │       │       Microsoft.Bcl.TimeProvider.dll
│   │       │       Microsoft.Extensions.DependencyInjection.Abstractions.dll
│   │       │       Microsoft.Extensions.DependencyInjection.dll
│   │       │       Microsoft.Extensions.Features.dll
│   │       │       Microsoft.Extensions.Logging.Abstractions.dll
│   │       │       Microsoft.Extensions.Logging.dll
│   │       │       Microsoft.Extensions.Options.dll
│   │       │       Microsoft.Extensions.Primitives.dll
│   │       │       Newtonsoft.Json.dll
│   │       │       System.Diagnostics.DiagnosticSource.dll
│   │       │       System.IO.Pipelines.dll
│   │       │       System.Net.ServerSentEvents.dll
│   │       │       System.Runtime.CompilerServices.Unsafe.dll
│   │       │       System.Text.Encodings.Web.dll
│   │       │       System.Text.Json.dll
│   │       │       System.Threading.Channels.dll
│   │       │
│   │       └───net8.0
│   │           └───runtimes
│   │               └───browser
│   │                   └───lib
│   │                       └───net8.0
│   ├───Commands
│   │       CommandPattern.cs
│   │
│   ├───Controllers
│   │       InviteCollaborators.txt
│   │       PlaylistsController.cs
│   │
│   ├───DTOs
│   │       AddSongDto.cs
│   │       CreatePlaylistDto.cs
│   │       VoteDto.cs
│   │
│   ├───Hubs
│   │       PlaylistHub.cs
│   │
│   ├───Models
│   │       Models.cs
│   │       Playlist.cs
│   │       Song.cs
│   │       User.cs
│   │
│   ├───obj
│   │   │   CollaborativePlaylistBuilder.API.csproj.nuget.dgspec.json
│   │   │   CollaborativePlaylistBuilder.API.csproj.nuget.g.props
│   │   │   CollaborativePlaylistBuilder.API.csproj.nuget.g.targets
│   │   │   project.assets.json
│   │   │   project.nuget.cache
│   │   │
│   │   └───Debug
│   │       ├───net6.0
│   │       │   │   .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
│   │       │   │   apphost.exe
│   │       │   │   Collabor.4AB95B3C.Up2Date
│   │       │   │   CollaborativePlaylistBuilder.API.AssemblyInfo.cs
│   │       │   │   CollaborativePlaylistBuilder.API.AssemblyInfoInputs.cache
│   │       │   │   CollaborativePlaylistBuilder.API.assets.cache
│   │       │   │   CollaborativePlaylistBuilder.API.csproj.AssemblyReference.cache
│   │       │   │   CollaborativePlaylistBuilder.API.csproj.CoreCompileInputs.cache
│   │       │   │   CollaborativePlaylistBuilder.API.csproj.FileListAbsolute.txt
│   │       │   │   CollaborativePlaylistBuilder.API.dll
│   │       │   │   CollaborativePlaylistBuilder.API.GeneratedMSBuildEditorConfig.editorconfig
│   │       │   │   CollaborativePlaylistBuilder.API.genruntimeconfig.cache
│   │       │   │   CollaborativePlaylistBuilder.API.MvcApplicationPartsAssemblyInfo.cache
│   │       │   │   CollaborativePlaylistBuilder.API.pdb
│   │       │   │   CollaborativePlaylistBuilder.API.sourcelink.json
│   │       │   │   rjsmcshtml.dswa.cache.json
│   │       │   │   rjsmrazor.dswa.cache.json
│   │       │   │   staticwebassets.build.endpoints.json
│   │       │   │   staticwebassets.build.json
│   │       │   │   staticwebassets.build.json.cache
│   │       │   │   staticwebassets.references.upToDateCheck.txt
│   │       │   │   staticwebassets.removed.txt
│   │       │   │
│   │       │   ├───ref
│   │       │   │       CollaborativePlaylistBuilder.API.dll
│   │       │   │
│   │       │   ├───refint
│   │       │   │       CollaborativePlaylistBuilder.API.dll
│   │       │   │
│   │       │   └───staticwebassets
│   │       └───net8.0
│   │           │   .NETCoreApp,Version=v8.0.AssemblyAttributes.cs
│   │           │   ApiEndpoints.json
│   │           │   apphost.exe
│   │           │   CollaborativePlaylistBuilder.API.AssemblyInfo.cs
│   │           │   CollaborativePlaylistBuilder.API.AssemblyInfoInputs.cache
│   │           │   CollaborativePlaylistBuilder.API.assets.cache
│   │           │   CollaborativePlaylistBuilder.API.csproj.AssemblyReference.cache
│   │           │   CollaborativePlaylistBuilder.API.csproj.CoreCompileInputs.cache
│   │           │   CollaborativePlaylistBuilder.API.csproj.FileListAbsolute.txt
│   │           │   CollaborativePlaylistBuilder.API.GeneratedMSBuildEditorConfig.editorconfig
│   │           │   CollaborativePlaylistBuilder.API.MvcApplicationPartsAssemblyInfo.cache
│   │           │   CollaborativePlaylistBuilder.API.sourcelink.json
│   │           │   staticwebassets.references.upToDateCheck.txt
│   │           │   staticwebassets.removed.txt
│   │           │
│   │           ├───ref
│   │           ├───refint
│   │           └───staticwebassets
│   ├───Properties
│   │       launchSettings.json
│   │
│   └───Services
│           PlaylistService.cs
│
├───CollaborativePlaylistBuilder.WinForms
│   │   CollaborativePlaylistBuilder.WinForms.csproj
│   │   CollaborativePlaylistBuilder.WinForms.csproj.user
│   │   Program.cs
│   │
│   ├───bin
│   │   └───Debug
│   │       ├───net6.0-windows
│   │       │       CollaborativePlaylistBuilder.WinForms.deps.json
│   │       │       CollaborativePlaylistBuilder.WinForms.dll
│   │       │       CollaborativePlaylistBuilder.WinForms.exe
│   │       │       CollaborativePlaylistBuilder.WinForms.pdb
│   │       │       CollaborativePlaylistBuilder.WinForms.runtimeconfig.json
│   │       │       Newtonsoft.Json.dll
│   │       │
│   │       └───net8.0-windows
│   ├───Forms
│   │       AddSongForm.cs
│   │       CreatePlaylistForm.cs
│   │       InviteCollaboratorsForm.cs
│   │       MainForm.cs
│   │       MainForm.Designer.cs
│   │       RankingsForm.cs
│   │
│   └───obj
│       │   CollaborativePlaylistBuilder.WinForms.csproj.nuget.dgspec.json
│       │   CollaborativePlaylistBuilder.WinForms.csproj.nuget.g.props
│       │   CollaborativePlaylistBuilder.WinForms.csproj.nuget.g.targets
│       │   project.assets.json
│       │   project.nuget.cache
│       │
│       └───Debug
│           ├───net6.0-windows
│           │   │   .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
│           │   │   apphost.exe
│           │   │   Collabor.656706C1.Up2Date
│           │   │   CollaborativePlaylistBuilder.WinForms.AssemblyInfo.cs
│           │   │   CollaborativePlaylistBuilder.WinForms.AssemblyInfoInputs.cache
│           │   │   CollaborativePlaylistBuilder.WinForms.assets.cache
│           │   │   CollaborativePlaylistBuilder.WinForms.csproj.AssemblyReference.cache
│           │   │   CollaborativePlaylistBuilder.WinForms.csproj.CoreCompileInputs.cache
│           │   │   CollaborativePlaylistBuilder.WinForms.csproj.FileListAbsolute.txt
│           │   │   CollaborativePlaylistBuilder.WinForms.dll
│           │   │   CollaborativePlaylistBuilder.WinForms.GeneratedMSBuildEditorConfig.editorconfig
│           │   │   CollaborativePlaylistBuilder.WinForms.genruntimeconfig.cache
│           │   │   CollaborativePlaylistBuilder.WinForms.pdb
│           │   │   CollaborativePlaylistBuilder.WinForms.sourcelink.json
│           │   │
│           │   ├───ref
│           │   │       CollaborativePlaylistBuilder.WinForms.dll
│           │   │
│           │   └───refint
│           │           CollaborativePlaylistBuilder.WinForms.dll
│           │
│           └───net8.0-windows
│               │   .NETCoreApp,Version=v8.0.AssemblyAttributes.cs
│               │   apphost.exe
│               │   CollaborativePlaylistBuilder.WinForms.AssemblyInfo.cs
│               │   CollaborativePlaylistBuilder.WinForms.AssemblyInfoInputs.cache
│               │   CollaborativePlaylistBuilder.WinForms.assets.cache
│               │   CollaborativePlaylistBuilder.WinForms.csproj.AssemblyReference.cache
│               │   CollaborativePlaylistBuilder.WinForms.csproj.CoreCompileInputs.cache
│               │   CollaborativePlaylistBuilder.WinForms.csproj.FileListAbsolute.txt
│               │   CollaborativePlaylistBuilder.WinForms.GeneratedMSBuildEditorConfig.editorconfig
│               │   CollaborativePlaylistBuilder.WinForms.sourcelink.json
│               │
│               ├───ref
│               └───refint
└───Shared
    ├───Interfaces
    │       ICommand.cs
    │       IPlaylistRepository.cs
    │
    └───Repositories
            PlaylistRepository.cs
