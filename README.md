# GameJam Quickstart (for Unity)
A Unity's project setup with basic managers and stuff for a quick game developing start.

![It's cute face](quickstart-looks.png)

## Overview
This is a personal compilation of generic code and configurations that I personally always end up making when starting a new game project in Unity. In short terms, it's a simple base to start any game, but specially for small and Jam games, that comes with some practical and necessary features.

## Content
A ready to use Unity's project with a basic game loop functionality (no actual game included tho). It has three main "Managers" scripts to handle the game's core procedures:
* **Game Manager:** containing "top-level" methods such and `GameStart()`, `GamePause()` and UI methods like `ShowMainMenu()`, in which they do as you'd expect.
* **Pool Manager:** a robust object pooling with a somewhat nice interface (in the Inspector) to simplify it's usage.
* **Sound Manager:** to play your sounds and music without a hassle. Simple calls like `PlayMusic()` or `PlaySfx()` will work nicely.

All these managers are made using a Singleton pattern, exposing their instances statically. So in the Game Manager you could start the music and create the object pools doing the following:

```csharp
private void Start()
{
  PoolManager.Instance.CreatePools();
  SoundManager.Instance.PlayMusic();
}
```

The managers are the most interesting bit. Besides them, this project comes with other minor scripts with miscellaneous features, and example images and sounds so it looks like an actual game.

## Credits
To build this up, I got some good stuff from some nice guys:
* The **Pool Manager** uses a slightly modified thefuntastic's [Unity object pool](https://github.com/thefuntastic/unity-object-pool).
* The **Sound Manager** set up used Jeff Johnson's [Sound Manager](https://assetstore.unity.com/packages/tools/audio/sound-manager-audio-sound-and-music-manager-for-unity-56087), available at the Unity's Asset Store.
* Those cool **icons** are from [https://game-icons.net](https://game-icons.net/).
* The **title art** was created using this [retro wave title generator](https://photofunia.com/effects/retro-wave) thing.
* The **music** is [CaesarBoston's artwork](https://soundcloud.com/caesarboston/exploration-preview), available for free at the [Asset Store](https://assetstore.unity.com/packages/audio/music/retro-style-video-game-music-47825)
* And I used [Bfxr](https://www.bfxr.net/) to make the simple but cool **sound effects** (try it out).
