---
layout: post
title: Book Report - Building Microservices
description: Thoughts on the book "The Effective Engineer" by Endmond Lau
permalink: /building-microservices
---

Building Microservices, by Sam Newman and published by O'Reilly, focuses on, as you may guess, actually building microservices, as well as the problems and scenarios you're likely to face as someone building those microservices, in a medium to large company. It's certainly one of the more popular books on microservices, and with good reason too, as it goes into the kind of detail that will allow you to actually know what you're talking about when the topic comes up, and even potentially make informed decisions on whether or not microservices are right for you and your problem domain.

It has a lovely website here: [https://samnewman.io/books/building_microservices/](https://samnewman.io/books/building_microservices/) that gives a short overview but no extra notes or snippets/addendum from the book.

If you happen to be looking out for it in a bookstore, it looks like this:

![building-microsites-cover](https://user-images.githubusercontent.com/1202911/43213368-5a959662-902e-11e8-807c-7a7ad2c53589.jpg)

This blog post is part of my "Book Report" series, where while reading a book I've been recommended I'll take informal notes on each chapter and then type them up at the end as a blog post I can reread later as both a refresher and a place to note down my thoughts on the book in general.

## Chapter Breakdown

### Chapter 1 - Microservices

This chapter provides a nice introduction to the world of microservices, as well as conveying a few key principles to the reader. A few of the principles are things such as how communication between services should really be through network calls, as this allows for a hard boundary, and how a lot of the goal of microservices as an approach is the ability to be able to deploy a single service without changing anything else. To me at least, this shares a lot of ideology with functional programming, in the sense that you want to minimise side effects as much as possible.

### Chapter 2 - The Evolutionary Architect

Architect when referring to the title in a development sense seems to be a title that generally attracts a lot of friction. This chapter acknowledges this and points out that it's not the greatest term, it's still the best that we have available to describe the kind of work someone "architecting" how a system should be implemented. I thoroughly agree with the sentiment, despite the fact it's my current job title.

Relating more to procedure, this chapter also mentions that defining the communication between services is important, and starts broaching the subject of standardization in various areas.

### Chapter 3 - How to Model Services

This chapter essentially provides a condensed version of the topics covered in both "Domain Driven Design" by Eric Evans, and "Implementing Domain-Driven Design" by Vaughn Vernon. The chapter also of course tailors a lot of the approaches to microservices, and stresses the point that getting boundaries right between services can be tricky, but is also remarkably important.

### Chapter 4 - Integration

This chapter gives you quite a few things to avoid doing, and mentions a lot of the complexities of shared databases. The key takeaway I got from it was to treat a database as a large, shared API, but a very brittle one.

The ["Fallacies of Distributed Computing"](https://en.m.wikipedia.org/wiki/Fallacies_of_distributed_computing) are also talked about in this chapter, which I'd recommend checking out if you hadn't heard of them already, they're a lot more common than you would think.

Overall this is a pretty dense chapter, there's a lot covered. It could maybe have benefitted by cutting out a few of the things to avoid, or condensing them a tad. That said, there's a lot of implementation details here that really show the wealth of knowledge the author has on microservices.

### Chapter 5 - Splitting the Monolith

The focus this time is on "Seams", the term defined by Michael Feathers in his seminal work, "Working Effectively with Legacy Code", which I'd highly recommend. Essentially a seam is a portion of code that can be sectioned off, and worked upon without side effects rippling through the rest of the codebase; a common problem in many legacy applications.

The chapter also touches on subjects such as eventual consistency, and talks a bit more about databases and their relation to microservices.

Essentially, this chapter is defined by the title, and really does provide some good approaches for exploiting seams in the monolith to start pulling it apart.

### Chapter 6 - Deployment

This was an interesting chapter really, not just for the things it talks about, but for the things it doesn't for most of the chapter. I was expecting to see Docker and LXC at the forefront of this one with quite a lot of detail, but they're actually pretty far back. It actually made me check when the book was released and if it was before Docker.

It also gives a few guiding principles such as single build for a single project, single repo etc.

It does echo a lot of the points that I've come across in real-world scenarios around deployment of various things, also mentions how a lot of Continuous Integration tools really fall down when they try to do Continuous Delivery. In my case I'd definitely say this is where something like [Octopus Deploy](https://octopus.com/) shines, although, as the book also mentions, this is something Linux still does a lot better than Windows.

### Chapter 7 - Testing

As the title of the chapter indicates, this one is all about testing. This was one of the much more technical chapters and had a lot to say about a lot of really nice tooling that I was previously unfamiliar with, such as [Mountebank](http://www.mbtest.org), [Pact and "Consumer-Driven Contracts"](https://docs.pact.io/documentation/what_is_pact_good_for.html), as well as mentioning Brian Marick's testing quadrant, shown below.

![Brian Marick's testing quadrant](https://user-images.githubusercontent.com/1202911/43215762-f73f5b82-9034-11e8-9ca8-276c3a427953.png)

I thoroughly enjoyed this chapter, since whereas a lot of books and articles tend to arrive at the point that "end to end tests are great" and then don't elaborate on that at all, this chapter provides very pragmatic and detailed approaches.

### Chapter 8 - Monitoring

This chapter clearly shows that the author knows what he's talking about, and not just in relation to microservices. The chapter gives a whistlestop tour of the various ways of monitoring your systems, with quick shout-outs to Nagios and New Relic, but doesn't mention my particular favourite, [Sentry](https://sentry.io/). The subject of correlation ids is also brought up, which is essentially the practice of tracing a call back to its origin by keeping a generated id throughout the lifecycle of the request, which makes a lot of sense.

### Chapter 9 - Security

The focus here is on securing communications between services as opposed to at a boundary of a service, which is a wise choice, if only if you compare the size of Building Microservices to something like The Web Application Hacker's Handbook.

The chapter does talk about JWT a bit, although there's been some negative press around JWT lately, so maybe this is something that will get updated in the next edition. If only individual chapters could be deployed like microservices, eh?

Overall the chapter does give a nice overview of OS based security, discusses OpenID Connect vs SAML, and a few good practices and common sense principles such as not writing your own crypto. It isn't exhaustive by any means, but if it was it probably would have meant this chapter would be the size of the rest of the book put together.

### Chapter 10 - Conway's Law and System Design

[Conway's Law](https://en.wikipedia.org/wiki/Conway%27s_law) is a nice little adage that tends to be truer than you'd expect at pretty much all levels an organization, and this chapter goes through why. It also focuses on how the structure of an organization will inherently affect the design of the system it produces, and mentions the "Two Pizza Team" saying, but in this case in relation to complexity.

There's also a fantastic quote from Gerry Weinberg which sums the chapter up entirely - "No matter how it looks at first, it's always a people problem."

### Chapter 11 - Microservices at Scale

This chapter starts off with a nice anecdote about Google's hard drives and how they're attached by velcro, I won't go into detail and spoil it, but it really sets the tone for the chapter, and illustrates the right mindset to have when thinking about scaling.

This chapter is again one of the more technical ones, and covers a varied list of subjects, from [Antifragile](https://en.wikipedia.org/wiki/Antifragile) to [CAP Theorem](https://en.wikipedia.org/wiki/CAP_theorem). It also provides a nice little overview of http-based caching. This echoes a few of the chapters where really, there's a lot to take away here, whether you're building a microservice or not.

### Chapter 12 - Bringing it All Together

A nice overview that ties everything together, very similar to the cheat sheet from "The Pragmatic Programmer". It also goes through when not to use microservices, which is nice, since a lot of books would probably just say "Always use them, and buy my next book, too".

### Background Information

There's a particularly interesting talk on [microservices given by the author here](https://www.youtube.com/watch?v=PFQnNFe27kU) which goes through a few points from the book, and provides a few updated points, too, which will undoubtedly be in the upcoming second edition.

The talk, and the book, also mention domain driven design a lot, for which there's a really fantastic explanation [here, on stack overflow, surprisingly.](https://stackoverflow.com/questions/1222392/can-someone-explain-domain-driven-design-ddd-in-plain-english-please/1222488)


### Overall Thoughts

I thought this was a really good book. Beforehand I really didn't understand microservices past an offhand chat here and there or the occasional horror story; afterwards however I can quite comfortably see a lot of the benefits and drawbacks. It really helps that a lot of the examples and methods talked about have a lot of real-world scenarios that really help to cement the points.

In summary, the book covers not only building microservices themselves, but covers a lot of the topics that are involved in modern software development, and in general, getting systems built and shipped. I'd really recommend it.