---
layout: post
title: Android Color Picker
description: How and why I packaged up the AOSP colour picker for Gradle
---

Recently, while putting together an Android project, I found that I needed a good dialog for the user to pick a colour. Not being a fan of reimplementing the colour-picker shaped wheel, I figured there had to be a decent colour picker out there that aligned with what I wanted from my colour picker.

What I found was that of course there was! While there were a number of colour pickers that allowed the user to pick a hex value from a grid, or show a large colour spectrum and have the user place a pointer at the point of colour they want, this wasn't what I wanted. All I wanted was a simple colour picking dialog, similar to the one found in the stock Google calendar.

So I just used that one. The problem with this however was how unwieldy it was to include in my project. Instead of a standard gradle dependency or anything of the sort, all that there was was source code. Which is okay, I can build source code, I can include AAR files in my project. Not particularly easily, but I can do it.

But this made me think, others shouldn't have to spend a few hours poring through the source to try and figure out what to build and how the component works, so why don't I make things better than how they were, and put together a Gradle build for the colour picker, making the next person who needs what I did happier, and learning a little more about Gradle along the way maybe.

And so from that I created the build, spent a good amount of time figuring out JCenter, and got the library published.

So now if anyone needs the AOSP colour picker, all they need to do is go [here.]() Or even just add the line

`compile 'uk.co.jordanrobinson:android-color-picker:1.0.1'`

To their Gradle file, add a small amount of code and boom:

![example-use](https://cloud.githubusercontent.com/assets/1202911/6986937/2475346e-da3a-11e4-99c5-0aeb3a0bcaa7.gif)

Much easier than an AAR file, right?
