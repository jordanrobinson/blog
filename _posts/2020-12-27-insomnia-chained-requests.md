---
layout: post
title: Chaining Requests and Using Variables in Insomnia
description: A quick walkthrough on how to chain requests using variables, in the rest client Insomnia.
permalink: /insomnia-chained-requests
---

## Insomnia

[Insomnia](https://insomnia.rest) is an open source rest client often thought of as a lightweight modern alternative to [Postman](https://www.postman.com/). In the past year or so I've used it a lot more than I have Postman, if only due to the quicker startup times, less bloat, and much easier to use UX. 

I'd really recommend it, switching is easy too, as it supports importing a lot of things, such as collections, from Postman. While there isn't support for some of the more esoteric features in Postman, Insomnia makes up for it by being immensely more usable.

## Chained Requests

Chaining requests is a practice that allows you to take the token or information from one request, store it in a variable temporarily, and then use that as authentication or input for another request.

Insomnia has support for this out of the box, and while there are a few bits of information in their [docs](https://support.insomnia.rest/article/43-chaining-requests), (as well as a gif that moves way too fast) they assume that you are quite familiar with Insomnia. As such I ended up documenting how to do this for myself and thought it would also make a good blog post.

Firstly, you will need to have an environment to store your variable in, this is as simple as clicking the manage environments button (or using the shortcut, ctrl+e) just below the Insomnia header, shown here:

![insomnia environments](https://user-images.githubusercontent.com/1202911/103244551-47c3e380-4955-11eb-8d7d-51724ee18c11.png)

Then, you'll need to add a variable for the variable you want to pass along between requests. The syntax of these environments is JSON, so you can just quite happily call your variable whatever you want. Once you have it you'll want to triger the autocomplete for the value (ctrl + space) and select `Response -> Body Attribute`. 

Note you can also have headers and urls here, but for the example we have let's just use an attribute from the response body.

![variable setup](https://user-images.githubusercontent.com/1202911/103244555-48f51080-4955-11eb-9931-85490aaa6753.png)

This will then give you a clickable item, which when clicked opens a means to edit the variable, which in this menu is described as a tag.

![variable modal](https://user-images.githubusercontent.com/1202911/103244554-485c7a00-4955-11eb-97c0-9ce6dc03f2ac.png)

Of note here is that we've selected a request to bring our variable from (the `Request` section of the modal) and the `Filter` section. The `Filter` allows us to filter down the json of the response to use a variable, for example a token from a response. We can also set when this is resent, e.g 86400 seconds, which would be once per day.

For this example in the image I've set it to filter on `$.species`, to give you an idea of how to filter, but for the rest of this, let's assume that we then use the filter `$.species.name`, which will give us `ditto` in the live preview window.

Now that we've defined our variable, to use it in another request, we simply need to open the autocomplete where we need it, whether that's in the url or the headers, query string etc.

![second request setup](https://user-images.githubusercontent.com/1202911/103244556-48f51080-4955-11eb-80f9-80d1db23492a.png)

And that's it! You can also reuse this variable in multiple requests. The most useful thing I've found to do with variables in this way is to create a request that gets a token, then use that same bearer token as authorisation for all the api requests stored in insomnia. You do have to add the variable manually as a header/auth method, however once done this never needs to be touched agan.
