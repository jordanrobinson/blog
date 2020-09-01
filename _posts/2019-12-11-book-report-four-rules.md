---
layout: post
title: Book Report - Understanding the Four Rules of Simple Design
description: Thoughts on the book "Understanding the Four Rules of Simple Design" by Corey Haines
permalink: /four-rules
---

Understanding the Four Rules of Simple Design is a relatively short book with a big focus on TDD and the way that it affects how we approach design. While the book is pretty concise, the contents is detailed and at times insightful.

It has a website here: [https://leanpub.com/4rulesofsimpledesign](https://leanpub.com/4rulesofsimpledesign) where you can buy it, too.

If you're looking out for it in a bookstore, it looks like this:

![four-rules-cover](https://user-images.githubusercontent.com/1202911/91866582-96dd5e80-ec6a-11ea-880e-b1d36559948e.png)

It's by Corey Haines, who has a blog here: [https://articles.coreyhaines.com/](https://articles.coreyhaines.com/) that has some interesting posts and also some additional information around the book itself.

This blog post is part of my "Book Report" series, where while reading a book I've been recommended I'll take informal notes on each chapter and then type them up at the end as a blog post I can reread later as both a refresher and a place to note down my thoughts on the book in general.

## Section Breakdown

### Part 1 - This Book

This section is much more of an introduction to the book itself than anything else, but I did like how it outlined that the examples are in Ruby, who it's for, and the overall structure of the book itself.

I did find it a bit odd that it didn't go into the [four simple rules themselves](https://martinfowler.com/bliki/BeckDesignRules.html) at this point when talking about what the book will be about. There's a foreword from Kent Beck himself talking a bit about them, but the assumption here is that you know what they are and have done a bit of background reading previously.

### Part 2 - Where do these thoughts come from?

Like the book itself, this section is pretty small but has a lot of parts to unpack and think about. In particular there are a lot of nice quotes in here that are good talking points, e.g.
 - "We'll never be more ignorant than we are at this moment"
 - "If you have to ask how fast your test suite should be, it should be faster"
 - "This is going to change in the future, so it is worth my investment right now."

This section is littered with nice little quotes like this that make you think and are easy to agree with.

As well as this it also touches briefly on code ownership, which I've thought and read about a lot before. The key post that cemented this for me is ["You are not your code."](https://www.hanselman.com/blog/YouAreNotYourCode.aspx) by Scott Hanselman. The book posits that you can get past this through practice, and while I agree in part, I do think that this is mainly a psychological barrier that can be easy to put up; since fundamentally it's nice to take pride in your work.

This section also outlines Conway's game of life as well, which was the main problem tackled at code retreat, and then details the four rules themselves. In the book they're described as: 

1. Tests Pass
2. Expresses Intent
3. No Duplication (DRY)
4. Small

Which is a little simplified from the original rules but convey the same intent.

### Part 3 - Examples

This section starts the main thrust of the book, and has a lot of really interesting insights and talking points. The examples are easy to follow and really very illustrative of the concepts the author is trying to convey.

One of the key themes of this section (and indeed book) is about asking questions around the design - with a lot of the design being iteratively answered through questions, in the same way that when driving your design through tests that your design iteratively takes shape.

There's really a lot to cover in this section (and a lot of it really interesting) so to pick out just one part, in particular I liked the part "Don't have tests depend on previous tests". This is something I've had come up quite a bit when reviewing other code and had to force myself not to do previously, so to see it here articulated a lot better than I have in the past was really nice. The crux of the section is that by having your tests rely on each other, you end up with a fragile test system. Your tests should be explicit when they fail as opposed to having one failure break many tests; causing you to spend a lot of time investigating.

While this section is pretty dense and the examples are only loosely connected in places, it does a very good job of the overall aim of the book, which is to help you understand the four simple rules of design. The examples are good at showing the fallacies that can sometimes occur and overall does a really good job of explaining why the rules are what they are in a clear and concise manner; something I find a lot of books on software design and TDD struggle with.

### Part 4 - Other Good Stuff

This section has some addendum that didn't really fit in the main section of the book, including things such as pair programming thoughts, example constraints for running through the game of life problem in a pair, and further reading. That's not to say that there isn't a lot of wisdom here however, since there most certainly is.

In particular one point that I really liked and that I've definitely taken with me after reading this book is the thought that the 4 rules are simple enough to apply consciously, whereas things like SOLID are best internalized and applied subconsciously.

### Overall Thoughts

This is probably one of my favourite technical books and really has stuck with me in a lot of my day-to-day working and thoughts on development and design. It's short but it has a lot to say and the things it does have to say are very thought-provoking.

I'd really recommend picking it up if you haven't already, and when possible, practicing pairing and tdd through some of the constraints and examples in the book. Some of them can be a bit labourious ("No return values" in particular really makes the functional programming part of my brain scream a bit) and some of them are definitely more fun than others, but overall pairing through a kata this way is a really nice way to hone your craft and learn from others.  