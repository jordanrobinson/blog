---
layout: post
title: The simplest possible 404 and 500 pages for Sitecore
description: Absolute minimal effort 404 and 500 pages in Sitecore
permalink: /simplest-error-pages-sitecore
---

## The Problem

In 8.2, Sitecore has finally fixed the almost legendary [404 showing as a 302 bug](https://laubplusco.net/handling-404-sitecore-avoid-302-redirects/) that everyone by now is really familiar with having to fix, however while we're now correctly reporting the right error codes, what we don't have is a custom branded 404 or 500 page.

While there are a lot of solutions to this problem online, in fact it's probably one of the most common problems faced by a Sitecore developer, most of them involve a lot of work and provide features you may not need depending on your implementation; such as a content editable 404 page, or multilingual 500 pages.

As such, now that the errors no longer show as 302 when thrown through Sitecore, we can quite easily put together custom error pages with only a few small changes to configuration files and adding the pages themselves.

## The Code

So to begin, let's change some settings so that our 404 and 500 will be picked up by Sitecore and our webapp. Add these through a transform to your Sitecore settings:

{% gist jordanrobinson/b05566968a33d0f8d47f77755c5270d0 settings.txt %}

Then you'll also need these settings to be modified in your web config file:

{% gist jordanrobinson/b05566968a33d0f8d47f77755c5270d0 web-config-settings.txt %}

Then, we'll of course need to add the two files that we're pointing at in those settings, so first off let's add a `500.htm` file to our solution, it just needs to be a plain html file. Ideally of course you want to [embed your images](https://en.wikipedia.org/wiki/Data_URI_scheme) so that you're only making one call to the server.

The 404 page needs to be a little more complex, since we'll be using the inbuilt Sitecore functionality:

{% gist jordanrobinson/b05566968a33d0f8d47f77755c5270d0 404.aspx %}

But with both of those added and configured, we've set up our own 404 and 500 pages, and pretty quickly, too.