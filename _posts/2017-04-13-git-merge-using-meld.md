---
layout: post
title: Using Meld as a Git Merge Tool on Windows
description: Taking advantage of the new Windows subsystem for Linux updates
permalink: /meld-as-git-merge-tool-windows
---

Recently Windows 10 has updated with the "Creators Update" which, while I know you're all really excited for the 3D mode for ms paint, also includes a whole host of updates for the [Windows Subsystem for Linux](https://blogs.msdn.microsoft.com/commandline/2017/04/11/windows-10-creators-update-whats-new-in-bashwsl-windows-console/), including Windows Linux interoperability.

What does this mean? Well, among other things you can now launch windows programs from your bash command line. One nice way we can make use of this is triggering a nice gui-based merge tool from the git command line.

Personally I quite like [Meld](http://meldmerge.org/) which is a nice free diffing tool for text.

![meld](images/meld.jpg)

So to launch Meld as your diffing tool for git merges you simply need to do the following:

First, create a script to pass things over to Meld

{% gist jordanrobinson/e8d7b378b43855a225e495821ef2a370 meld.txt %}

this just launches the program and passes over any arguments using the `$@`.

Then, copy over the new script to your bin directory with

{% gist jordanrobinson/e8d7b378b43855a225e495821ef2a370 copy.txt %}

this allows us to launch it from wherever we want.

Then in your .gitconfig you just need:

{% gist jordanrobinson/e8d7b378b43855a225e495821ef2a370 .gitconfig %}

When you then launch the command using `git mergetool` in a repository that needs merges, it'll automatically launch meld and pass it all the files.
