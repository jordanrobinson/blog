---
layout: post
title: Building a .NET Core Application with CircleCI
description: Getting from nothing to built with CircleCI and .NET Core
permalink: /net-core-circle-ci
---

## Introduction

Lately I've been doing a lot of work using .Net Core and basically, it's great. Since I'm not building out using more legacy .Net stuff, that means as well that I can try out new things and processes. Usually for a standard .Net project I'd use TeamCity, which is really good to work with in a standard workflow, but it's very Windows-centric; things are configured through GUIs and checkboxes and forms. The main thing I don't like about this however is that it's not very portable. If we lost our TeamCity server with no backups (unlikely but still), we'd have to spend a good while getting things back up and running.

Enter [CircleCI](https://circleci.com/); CircleCI is a more straightforward and modern approach to CI in my opinion, without a lot of the legacy features and issues that tend to crop up from time to time when configuring a build in TeamCity. The premise is pretty simple, you specify a [yaml](https://en.wikipedia.org/wiki/YAML) configuration file with a few commands to run, and on check-in to git it reads the config file (stored in the same repository) and builds out accordingly, running tests and doing all the great stuff that CI does.

## Setting It All Up

So to combine the two, let's look at my yaml file that I ended up with, and then go through it line by line:

{% gist 115b770b16d17ce9f73f9076efd5af9a %}

So as you can see it's pretty straightforward and clocks in at just over 20 lines, which is really nice. First off we start with

```yaml
general:
  build_dir: CoolProject.AwesomeNamespace/src/YourSource.Directory
```
Which is pretty straightforward, right? that's the directory we want to build from. If we were running from the console, it would be where we ran the dotnet build command from (which we'll get to soon).

```yaml
dependencies:
  pre:
    - sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list' 
    - sudo apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
    - sudo apt-get update 
  override:
    - sudo apt-get install dotnet-dev-1.0.4
```
Okay so this is the only bit that might look a bit alien; what we're doing is installing a specific version of .net core on the vm that CircleCI spins up. We need to add the repository as a trusted repo, since (at the time of writing) it isn't available through apt otherwise. Basically this is currently the quickest way to install .net core on a server for building purposes.

You may also note I'm a little behind the times on versioning, but you'll have to excuse me on that one since I've not updated just yet.

```yaml
  post:
    - dotnet restore
```
This should look pretty familiar. The whole dependencies part of the yaml file is for setting up the dependencies (duh I guess) for the build itself. For our .net core app, all it needs at this point is .net core. In future maybe we need to set up other things for tests, or frontend processes like gulp, or who knows what. At the end of the dependencies phase, we do a dotnet restore, to get all our nuget packages and get ready for a build.

```yaml
compile:
  override:
- dotnet build
```
This part really speaks of the simplicity of CircleCI. All we're doing here (and really all we've been doing all along) is calling a bash command to build our app. The compile phase is the main part of the build process, as you'd expect, especially in a small build like this.

```yaml
  post:
    - dotnet publish -o $CIRCLE_ARTIFACTS
    - sudo apt-get install zip
    - zip -r $CIRCLE_ARTIFACTS/$(date -u +"%Y-%m-%d_%H-%M-%S").zip $CIRCLE_ARTIFACTS
```
Then we just do a little bit of linux-fu to publish out the changes to a directory built into CircleCI, and zip it up with a timestamp. My tar skills really aren't up to scratch so I just grab zip here, but you can definitely use it and probably do a better job than I have with -czf or whatever eldritch incantation that tar actually uses to compress things.

For my process I have something picking it up from there that unzips it so I wanted to just keep it simple, and use zip.

```yaml
test:
  override:
- "true"
```

Finally, I included this just to help people along. Really I have some tests (honest!) but I figured examples should be minimal and viable, so this will allow you to exclude tests and just get it building for now.

And that's it! That's all it takes to have a build process. The really nice thing about this is you can basically just flat out use that yaml file, whereas for TeamCity you'd have to click through all kinds of screens and copy values over, or mess around with templates.
