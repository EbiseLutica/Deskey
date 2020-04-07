# MisskeySharp

Misskey API library for C# / .NET Standard 2.1.

## Usage

### Create App and Authorize

#### By using MiAuth API

```cs
using System;
using System.IO;
using System.Text.Json;

using MisskeySharp;

var instance = "misskey.io";

if (!await Misskey.CheckFeaturesAsync(instance, Features.MiAuth))
{
    // If the platform doesn't support opening URI, it throws the exception
    Console.WriteLine("MiAuth is not supported at the instance.");
    Environment.Exit(-1);
}

// Create app and receive session object
var session = new MiAuthSession(
    instance,
    "MisskeySharp",
    "https://misskeysharp.xeltica/assets/icon.png",
    "http://localhost:9425",
    
    'read:account',
	'write:account',
	'read:blocks',
	'write:blocks',
	'read:drive',
	'write:drive',
	'read:favorites',
	'write:favorites',
	'read:following',
	'write:following',
	'read:messaging',
	'write:messaging',
	'read:mutes',
	'write:mutes',
	'write:notes',
	'read:notifications',
	'write:notifications',
	'read:reactions',
	'write:reactions',
	'write:votes',
	'read:pages',
	'write:pages',
	'write:page-likes',
	'read:page-likes',
	'read:user-groups',
	'write:user-groups'
);

// Open the URI with the platform-specific way
try
{
    Misskey.OpenUri(session.Uri);
}
catch (NotSupportedException)
{
    // If the platform doesn't support opening URI, it throws the exception
    Console.WriteLine("This platform is not supported.");
    Environment.Exit(-1);
}

Console.WriteLine("Press ENTER after you finished the authorization:");

Console.ReadLine();

Misskey mi = await Misskey.ConnectAsync(session);

// That's recommended to save your credential object as a file.
JsonSerializer.SerializeAsync(File.OpenWrite("credential.json"), mi.Credential);

// ---

// Load the credential object to initialize your Misskey client
var credential = JsonSerializer.DeserializeAsync<Credential>(File.OpenRead("credential.json"));
var mi = new Misskey(credential);

```

#### By using legacy API

```cs
using System;
using MisskeySharp;

// Create app and receive session object
Session session = await Misskey.CreateAppAsync(
    "misskey.io",
    "MisskeySharp",
    "A sharpened Misskey CLient",
    "localhost:9425",
    
    'read:account',
	'write:account',
	'read:blocks',
	'write:blocks',
	'read:drive',
	'write:drive',
	'read:favorites',
	'write:favorites',
	'read:following',
	'write:following',
	'read:messaging',
	'write:messaging',
	'read:mutes',
	'write:mutes',
	'write:notes',
	'read:notifications',
	'write:notifications',
	'read:reactions',
	'write:reactions',
	'write:votes',
	'read:pages',
	'write:pages',
	'write:page-likes',
	'read:page-likes',
	'read:user-groups',
	'write:user-groups'
);

// Open the URI with the platform-specific way
try
{
    Misskey.OpenUri(session.Uri);
}
catch (NotSupportedException)
{
    // If the platform doesn't support opening URI, it throws the exception
    Console.WriteLine("This platform is not supported.");
    Environment.Exit(-1);
}

Console.WriteLine("Press ENTER after you finished the authorization:");

Console.ReadLine();

Misskey mi = await Misskey.ConnectAsync(session);
```