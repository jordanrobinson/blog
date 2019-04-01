---
layout: post
title: Optimising Cloudfront from a Sitecore perpsective
description: Tips and thoughts on configuring Cloudfront for use with Sitecore.
permalink: /sitecore-and-cloudfront
---

### Why use AWS Cloudfront?

Recently I've been doing an extensive amount of work with both AWS and Sitecore, with site performance and reliability being the main aim. What this led to is us analysing how we use Cloudfront as a CDN, and offloading as much as we can over to it. As such I thought I'd write up a few of the tips I picked up along the way, relating not just to Sitecore, but Cloudfront in general.

Generally, people use Cloudfront for serving images, although you can serve other static assets, or even serve a whole site through the platform. It allows for edge caching, which means geolocated servers, which of course means a fast website.

### Have a test environment that matches your production environment

This is probably the golden rule when implementing systems like these, since you don't want to be trying out new settings on a production instance. I've seen many implementations where people try to spend a bit less by not having the infrastructure of the test environments match that of production, and while obviously they don't need to be of the same scale, the setup should be similar. This carries over to Cloudfront, where a test distribution is probably the only way to reliably test new Cloudfront behaviour settings, as well as new functionality in your webapp coexisting with Cloudfront.

### Get familiar with the cache statistics page

![cache-statistics-1](https://user-images.githubusercontent.com/1202911/55343337-c77ffe00-54a2-11e9-9eca-999b16e18854.jpg)

The cache statistics page should be your first port of call when testing or debugging your Cloudfront distribution, as it provides very useful, detailed statistics on how well your distribution is working. With time, you want to be aiming for a hitrate above 99% for your assets to maximise the efficiency of the cache. Tweaking the behaviour settings for your distribution to achieve this can be somewhat of a trial and error process, since every webapp has different requirements, but as a starting point I'd recommend leaning towards anything that improves caching, then adapting based on testing your implementation.

Here are some example settings from one of our projects, however you will need to tweak things based on your specific needs.

![cache-settings-1](https://user-images.githubusercontent.com/1202911/55343317-c0f18680-54a2-11e9-8a07-61ed2133e104.jpg)

![cache-settings-2](https://user-images.githubusercontent.com/1202911/55343327-c51da400-54a2-11e9-8476-9b057b96e5ea.jpg)

Another neat little trick you can do is to set the header in the Chrome dev tools to show on network requests, so you can get a nice overview of your assets and what is and isn't hitting Cloudfront.

This is done by simply right clicking on the column names in the network tab, selecting "Manage Header Columns..." and adding a custom column called "x-cache" which is the header that Cloudfront returns.

![cache-header-1](https://user-images.githubusercontent.com/1202911/55343302-ba630f00-54a2-11e9-8947-167d834defb0.jpg)

Once you've done this you should be able to see which assets are and are not hitting Cloudfront. Bear in mind however this is just from your machine, and should be taken with a pinch of salt; people in other parts of the world or with different setups or request headers could have a totally different experience.

![cache-header-2](https://user-images.githubusercontent.com/1202911/55343312-bd5dff80-54a2-11e9-8189-fe7092e7936c.jpg)

### Offload everything you can

This one might be obvious but you want to be offloading everything you can to the CDN, not just images. If you can offload scripts, styles and fonts, then you should. You can even take it further and offload api endpoints if the data is unlikely to change. One setting we use is that we cache based on query string; this lets us bust the cache for new deployments of the site, as we have version query strings for our static assets. Caching based on query string also means that your images can pass through height and width parameters, or any custom image parameters you might have, caching the end result flawlessly. 

A common gotcha for fonts is CORS, as since you most likely will be serving your static assets from another domain, CORS will block them without the correct configuration. We got around this by allowing for GET, HEAD and OPTIONS methods, as well as passing through the "Access-Control-Allow-Origin" header. Bear in mind this will also require a bit of work on your webapp, to pass through the relevant header. [More information on this can be found in this stack overflow post here.](https://stackoverflow.com/questions/39647732/enabling-cors-on-iis-for-only-font-files)

Sitecore of course has its own HTML caching functionality and you should lean on this heavily for pages instead of using Cloudfront, as otherwise functionality such as A/B testing, personalization and even publishing won't work correctly. But aside from this, practically everything is fair game.

### The Sitecore Changes

The Sitecore configuration changes are actually relatively simple, although if you're using any computed fields or link generation outside of the standard out of the box functionality, it can get a little complicated. Assuming you're just looking at the default, the main point of integration is that of the MediaProvider. You'll need a configuration such as the following:

{% gist ebb54f0551f0dde08fc1d27abe4e2466 CDN.config %}

Then that provider should extend the default MediaProvider, and override GetMediaUrl with your own implementation. This is so we can make sure that modifications and new versions of the image pull through. There's a nice implementation from the [incredibly knowledgeable JammyKam here, as well as a lot of really useful tips for Cloudfront's Azure counterpart.](https://jammykam.wordpress.com/2017/02/13/sitecore-azure-cdn/)

An alternative approach would be to hash the image and use that as a query string, but when looking into this bear in mind this is different from the current hash that Sitecore puts in the request query string, [which is described here.](https://briancaos.wordpress.com/2018/04/16/sitecore-what-is-the-hash-property-in-the-image-query-string/) and worth thinking about if you have any issues with resizing.

With this in place, you should see your images in preview be using the new CDN url you've specified, though note in the example above, the role definition requires the role of content delivery, which I'd recommend to make sure there isn't any crazy experience editor issues.
