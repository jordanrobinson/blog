---
layout: post
title: In search of the best cache busting query string
description: A comparison of some of the ways you can bust a cache for static assets using a query string.
permalink: /cache-query-strings
---

## In search of the best cache busting query string

If you aren't already, you should be cache busting your scripts and styles, and what better way to do that by making the url unique, clearing both the browser cache and any CDNs that are configured correctly. A good explanation of this can be found [here.](https://stackoverflow.com/questions/9692665/cache-busting-via-params)

But if we were to take this a step further and automate it, what would this look like, and what are our options?

### Busting the cache based on version

If you're doing any kind of serious project, you're going to want some kind of automated versioning. We tend to use [GitVersion](https://gitversion.readthedocs.io/en/latest) for most of our projects here, which while it has a few foibles that can need ironing out depending on your continuous integration pipeline, I'd still recommend it as the defacto standard for generating out version numbers automatically.

Once you have a version number, it's a case of reading that version number from somewhere and stamping that into a variable, then outputting your files based on that variable. Here's a quick example:

{% gist 0e399dd9c5f8686b9615341e51fcec3d VersionHelper.cs %}

Then in your Razor or wherever you want to use it, you can just call it like this:

{% gist 0e399dd9c5f8686b9615341e51fcec3d VersionHelper.cshtml %}

This just gets you the version out of your assembly. This does require your build pipeline to be stamping the build onto your DLLs but apart from that it's a pretty neat solution to the problem. It's not my favourite though, for reasons I'll go into below.

Pros
  - Customisable based on your versioning strategy
  - Should produce unique version strings and bust accordingly
Cons
  - Requires a lot of setup on your part in terms of the CI pipeline
  - Since it relies on a lot of other things working, can break

### Busting the cache based on file modified date

This one is pretty similar to busting based on version, however, it doesn't rely on you having versioning setup and generally has a lot less maintenance. However, it's not as accurate as version based cache busting, or my preferred approach.

On top of that, if you have multiple content delivery servers, the timestamps could be different on each of them, which would mean browsers and CDNs would cache multiple versions of the same file.

With that said it's very easy to get working, and if you have a very small project it might be a good bet for a quick way of doing it.

A good example of this is [this stack overflow post.](https://stackoverflow.com/questions/4560693/getting-the-last-modified-date-of-an-assembly-in-the-gac)

Although like I say there's a few problems with it on larger projects.

Pros
 - Very quick to get up and running
Cons
 - Not as accurate as the other methods
 - Lots of drawbacks the larger your project gets


### Busting the cache based on git hash

This is my preferred approach, as your git hash should refer directly to the code itself, so there's no chance of a collision between versions, and it aligns with repeatable builds, which is something I really like.

The only real downside to this one is that it's a bit more computationally expensive than the others, so you likely want to cache it or use a singleton to generate it.

Here's the example, it uses [MSBuildGitHash](https://github.com/MarkPflug/MSBuildGitHash) which needs a small modification to your csproj so it can stamp the DLL with your git hash. After that you just need the following code to get the version out:

{% gist 0e399dd9c5f8686b9615341e51fcec3d GitHashVersionHelper.cs %}

Just replace the classname before the .Assembly call with your classname and you should be good to go.

Pros
 - Unique version string
 - Reproducible builds
 - Consistent across different servers or docker instances
 - Easy to pin down if changes break something
Cons
 - Setup can be fiddly
