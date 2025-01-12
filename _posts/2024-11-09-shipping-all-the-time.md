---
layout: post
title: Shipping all the time
description: Some thoughts on getting things deployed
permalink: /shipping-all-the-time
---

Something I've been thinking about a lot lately is shipping all the time and the realities of what that means as a developer.

Very frequently, I see opinions that are polarised on the topic. From people claiming that you should completely avoid deploying on Fridays and there should be a manual review process for every release, versus deploying all the time no matter the risk.

More recently, things like [Accelerate](https://itrevolution.com/product/accelerate/) (which is fantastic) and [DORA metrics](https://dora.dev/) have sought to statistically and scientifically prove that deploying more frequently is better. And I agree! The better systems I've worked on have been deployed multiple times a day, and the legacy, flaky or bad systems I've worked on often had long complicated release processes that had manual steps and schedules.

On top of this, users of your product just want it to work. Consider the following scenario where a fix is found for a bug but the fix has to wait till after the weekend and needs to be signed off by another team.

Users that only see your product sporadically, or for the first time, are going to see it as always being broken. The longer it's broken, the more of a network effect this has.

![Diagram of users getting unhappy because you didn't deploy](https://github.com/user-attachments/assets/8a88c0de-ff96-4ef1-8fa2-7fe8e3d03e0e)

While I'm very glad the discussion on this has shifted towards more frequently than less, there is a but. I don't think deploying all the time is a silver bullet that fixes everything.

The key consideration to have is that of Risk Bandwidth. This is illustrated particularly well in [chapter 3 of the Google SRE book](https://sre.google/sre-book/embracing-risk/). The idea being that zero risk is unattainable and leads to the kind of systems that very rarely deploy.

As such, as a developer you have to be mindful of the level of risk your deployment is going to cause, think about what can go wrong, who is going to get paged, and what would the impact be. This is going to be different in every situation based on what you're working on, who your users are, and what your team is like.

There's no one size fits all solution here and understanding the amount of risk incurred by your deployment and whether that is acceptable or not is a great skill to learn and be comfortable with.
