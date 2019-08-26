---
layout: post
title: Scaling Sitecore for high traffic sites
description: Common pitfalls and various tips on scaling Sitecore to deal with huge traffic.
permalink: /scaling-sitecore
---

### Scaling Sitecore for high traffic sites

Scaling Sitecore up is one of those things that, while very necessary, there aren't as many resources on the internet regarding the subject as I'd like. As such, I've decided to put together this post with a few tips and gotchas around scaling out to handle lots of traffic to your Sitecore site.

While there is the [Sitecore scaling scenarios](https://doc.sitecore.com/developers/90/platform-administration-and-architecture/en/sitecore-scaling-scenarios.html) document put out by Sitecore (though not yet available for 9.1) this does focus more on the infrastructure required and other concerns. While this is all very important, it forms a baseline that you can then build on; there are a lot of other factors in play that no matter the number of servers you scale up to, could still cause issues.

### The HTML Cache

In referring to this I'm talking about the rendering based caching, where you can set the settings of specific renderings to cache, and the ways of varying that cache to make sure that your site functions correctly. Sitecore's HTML cache is actually very good; being based on the standard .Net memory cache. You can even interrogate it through code and clear things yourself, as outlined in a really useful blog post [here.](https://briancaos.wordpress.com/2018/10/31/sitecore-9-caching-sitecore-caching-cachemanager-getallcaches-changed-from-sitecore-8/)

Best practice is of course to cache as much as possible. In particular I'd recommend anything with ajax or dynamic components using query strings to cache based on query string, and have the api endpoints or search pages idempotent. If you're unfamiliar with the concept there's a [nice blog post here explaining it.](http://cloudingmine.com/idempotence-what-is-it-and-why-should-i-care/)

![Sitecore content editor caching settings](https://user-images.githubusercontent.com/1202911/56134765-25bedd80-5f87-11e9-8492-846f7b167696.jpg)

However, the cache clearing strategy for this cache could be described as a little extreme; on any publish, the entire cache is evacuated. This means that while you could just be publishing, say, a single piece of content or dictionary entry, the entire site's HTML cache will be cleared and need to be re-cached. As such you have to be quite careful with what your renderings are doing, since if your content editors are likely to publish frequently, or during traffic spikes.

### Caching Across Multiple Servers

Also worth mentioning is that the HTML cache is that it is of course located on each machine. In any large website for Sitecore you're going to want multiple content delivery servers, but this means that the work to fill those caches is multiplied by the number of content delivery servers you have. Why is this a big deal? Well, if we look at this diagram we can see that this can have a cascading effect to other parts of the infrastructure, since if we double the amount of CD servers, everything else has to accommodate that.

![Scaling horizontally diagram](https://user-images.githubusercontent.com/1202911/56134777-2c4d5500-5f87-11e9-9f12-99a1c1245ca6.jpg)

Another problem with this is that things that are time-sensitive can vary between CD servers, since one server could be hit, for example, a minute after the other one. While they might both be valid, if a user refreshes and gets totally different data, this could cause all kinds of problems.

Ideally, the way to mitigate this would be to have one single cache that all the CD servers interact with, and use as a central store; however this is not supported, even though there have been quite a few questions about it in the Sitecore community, [such as this one.](https://community.sitecore.net/developers/f/8/t/8512#pi214filter=all&pi214scroll=false) This is something that I really hope is available in forthcoming versions of Sitecore.

### APIs and Assets

Scaling out APIs based on Sitecore is no trivial task, but there are a few points to be aware of. First off, you're going to want to offload as much of the requests that your API is using to your search service, whether this is Azure Search or Solr. Architecting it in this way greatly reduces the load on your content delivery servers and on your database, using the search servers for what they're intended for.

For your more frequently hit APIs, I would also recommend putting [Varnish](https://varnish-cache.org/intro/index.html) in front of the API, Varnish is a static caching layer. I've seen it handle truly staggering amounts of traffic, I really can't recommend it enough.

Finally, for assets, using a CDN is best practice, and [I've wrote a few bits and pieces on that before that you might want to check out.](https://blog.jordanrobinson.co.uk/sitecore-and-cloudfront)