---
layout: post
title: Hijacking Sitecore aliases and turning them into redirects in Sitecore 8
description: All about redirects and making a nice little pipeline modification to use aliases as redirects.
---

## Redirecting in Sitecore

Redirects are a very common feature that people ask for, whether due to their URL structure changing, SEO requirements or any number of reasons, they're a very nice thing to have, and even better when a non-technical user can create them without having to rely on IIS modifications.

Sitecore has a few options in this situation, for example I'm a big fan of the Sitecore URL Rewrite Module by Andy Cohen, found [here.](https://github.com/iamandycohen/UrlRewrite) If you haven't checked it out already, it provides a lot of the standard IIS rewrite module functionality, but through sitecore instead.

Another way of implementing redirects if you don't want something as heavy duty as the URL Rewrite module is by overriding aliases in Sitecore. You can provide redirects to the user, and at the same time restrict a feature of Sitecore that is pretty easy to misuse.

## Sitecore Aliases

Aliases are one of the features of Sitecore that, while useful, could be better. Often people don't realise the SEO implications of having two URLs for the same page, which is exactly what aliases do. While you could avoid a situation like this by implementing a canonical URL, as recommended by Google, in my opinion it's much better to simply hijack this functionality and use it to provide redirects instead.

## So What To Do?

Well, if we're going to hijack aliases, you'd expect us to have to write huge chunks of code and override all kinds of classes, right?

Nope! All we have to do is write a single pipeline modification, that comes in at just 60 lines of pretty simple code.

## The Code

Without further ado, here's all you need:

{% gist d57f227833e59f55e505 %}

After that, you just need a way of replacing out the alias resolving pipeline with our new and improved version. Since we know what we're doing, let's add this as an include and patch out the original pipeline, like so:

{% gist 29b8a19ca16f3e3282c4 %}

Of course don't forget to swap out the namespace for your own instead of launch sitecore. Once that's done, it's pretty simple to see the results, open your network tab and you'll see that your aliases have turned to redirects :D

![more validation setup](https://blog.jordanrobinson.co.uk/public/images/sitecore-redirects.jpg)

