---
layout: post
title: Injecting a custom icon into an Android icon pack
description: Quick how to on modifying a compiled Android icon pack
permalink: /injecting-android-icons
---

---

## Huge Disclaimer

Nowadays you can just use something like [Nova Launcher](https://play.google.com/store/apps/details?id=com.teslacoilsw.launcher) and swap the icons out yourself, so a lot of this post is pretty moot. But hey if you fancy a bit of reverse engineering then maybe there's something useful below, so I've left the old post intact cause why not.

---

Recently, I decided my Android home screen needed to look slightly fancier than it usually does, so I spent some time looking into icon packs and theming. All of which, for Android at least, there are a huge amount of options. Liking something simple, but that would still let me recognise what the apps actually were, I decided to go for [Whicons](https://play.google.com/store/apps/details?id=com.whicons.iconpack) which is a huge collection of HD icons.

But oh no! Disaster! One of the apps on my homescreen doesn't have an icon in the pack! The app in my case was the wonderful [Hacker News 2](https://play.google.com/store/apps/details?id=com.airlocksoftware.hackernews) but this is pretty common, either the app you're using is new, or not used by many people, or even has recently been updated.

Thankfully, Whicons has a fancy menu that lets you submit icons for the app author to review and add icons for. Sadly however, I'm immensely impatient, and since Whicons isn't open source, there's nowhere for me to do the work myself and submit a pull request.

So what to do? Well, let's inject our own icon for the app into the icon pack apk.

First off, we'll need the apk for the icon pack. I'll let you look into where to get this yourself, but safe to say, exporting apks is something that's pretty common so you shouldn't have any problems finding a guide.

Once we have the apk, we'll need [apktool](http://ibotpeaches.github.io/Apktool/) which will allow us to decompile the icon pack into a folder. Download this and point it at your apk with the command `./apktool.bat decode com.youriconpack.somethingheremaybe.apk` where the apk is the filename of your apk on disk.

This will output everything into a folder for you to take a look at. The important files for us in this case are `assets/appfilter.xml` and the `res/drawable-nodpi-v4` folder, which contains the image files themselves, in this case pngs.

Now we just need to modify the `appfilter.xml` file to point our app's activity at the icon in this icon pack. This can be done simply by adding another of the xml elements such as the following, which was what I used in my case:

{% gist 9b5cd4d2f7b051d4aa1fedd2bdc05ee8 %}

This just tells our icon pack to look at the activity specified, and render out the drawable resource that we'll now add. In my case I was rather lucky in that there was a drawable resource that was already pretty similar to what I wanted, but you may not have as much luck.

Create and add your image file into the folder mentioned above, `res/drawable-nodpi-v4` although bear in mind your icon pack may use a different folder under the res directory, and of course it makes sense to base your new icon on one of the existing icons in the pack for a nice consistent look.

Now that we've put our icon in place and told our icon pack where to look to replace it, we need to recompile with `./apktool.bat build com.youriconpack.somethingheremaybe.apk -o iconpack.apk` which will give us a fresh apk that we can install... Right? Well, no. We still need to sign it to tell Android that it's something safe to install.

For this you'll need an install of the JDK, so that you can use the keytool utility and the jarsigner utility. The commands are pretty simple, first off `keytool.exe -genkey -v -keystore personal-keys.keystore` to generate yourself a quick keystore. Any password will do, as long as you can remember it long enough to type it again in a minute.

Then, we need to sign the apk using jarsigner, this should be as simple as `jarsigner.exe -verbose -sigalg SHA1withDSA -digestalg SHA1 -keystore personal-keys.keystore iconpack.apk mykey` although you may have to try a different sigalg or digestalg. Also worth noting I had some problems with this when I was trying to run the jarsigner from a different directory than where it was located, putting the apk and keystore in the same directory as the jarsigner tool helped here, so if you get complaints that jarsigner is `unable to open jar file` then consider moving everything relative to the tool.

Now that we've signed our apk, all that remains is to install it and check out our new icon! Quick disclaimer: bear in mind this is really only meant as a quick way to put icons into an existing pack that may be missing, so please don't redistribute apks modified in this way and always respect the licenses of the original apk creator.
