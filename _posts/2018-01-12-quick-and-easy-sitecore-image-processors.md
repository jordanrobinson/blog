---
layout: post
title: Quick and easy image processors for Sitecore
description: Steps to create an image processor for Sitecore
permalink: /image-processors
---

## What's an Image Processor?

For quite some time now Sitecore has supported the ability to crop images and pass in other [parameters](https://briancaos.wordpress.com/2011/02/28/sitecore-image-parameters/) to change over the appearance of images displayed via media requests. It does this by using what it calls processors, and as part of a recent project, I got the opportunity to build one.

## What does it look like?

For my image processor, I decided the first thing to do was to keep it relatively simple, so I decided it would take a query string parameter and, based on it's value, add a tint to the media item.

To start out, we'll need a config file to patch in our new processor, and reserve a parameter to make sure it isn't used by anything else.

{% gist jordanrobinson/d5740f50928fb5cbe494fade98a40353 JordanRobinson.TintProcessor.config %}

Then, we'll need the actual code for the processor.

{% gist jordanrobinson/d5740f50928fb5cbe494fade98a40353 TintProcessor.cs %}

Note for this I'm using the great C# library [ImageProcessor](http://imageprocessor.org/) which as named pretty coincidentally in this situation.

We'll also need some code to intercept the request and push our parameter to where it should go.

{% gist jordanrobinson/d5740f50928fb5cbe494fade98a40353 TintMediaRequest.cs %}

With all that in place, if you're on a version higher than 7.5 you'll need to be mindful of [media request protection](https://sitecore.stackexchange.com/questions/249/mediarequestprotection-an-invalid-missing-hash-value-was-encountered) but that's a bit out of scope of this blog post, so I'd recommend following the approaches in that Sitecore stack exchange post.

For now, we can just [disable it](https://doc.sitecore.net/sitecore_experience_platform/setting_up_and_maintaining/security_hardening/configuring/protect_media_request) while we test out our feature locally, but you **definitely shouldn't** leave this off on a production instance.

So let's try it out, using a wonderful image from [Unsplash](https://unsplash.com/photos/FPyGfMHXWZU?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText)

All we'll need to do is go to the url of our image, in my case I've used `http://cool-website.local/example-image` which looks like this:

![example-tint-none](https://user-images.githubusercontent.com/1202911/34882312-21c07960-f7ae-11e7-9791-a954ebfac133.jpg)

then when we try it with our image processor with the url `http://cool-website.local/example-image?tint=ff0000` we get a nicely stylised image that looks like this:

![example-tint-red](https://user-images.githubusercontent.com/1202911/34882330-2acd4a4c-f7ae-11e7-8518-1aabc206f80c.jpg)

Which is a pretty awesome result for an hour or two of coding! 
