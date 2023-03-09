INCLUDE Globals.ink

VAR End = false

Welcome to heresy! I have been your guide, following you and watching you {~but I must warn you, not everything I say can be trusted.| I can reasure you, I am your friend and want to help you leave this place | I can see that maybe this is where you belong}

*UUh, okay. This sounds a bit ominous.
->Guide
~Heresy -=1

*I'm not sure this is where I belong. Can I leave?
~Heresy -= 1
->Guide

*Wait, you've been following me? That's a bit creepy.
~Heresy += 1
->Guide

*Okay then, I trust your
~Heresy -=1
->Guide

== Guide == 

Have you been enjoying yourself? You are approaching the final level of hell and your only chance to leave. Just remember, some of the challenges you'll face may not be as they appear.

*Can you give me an example?
~Heresy += 1
->Guide2

== Guide2 ==

Well, let's say you're playing a puzzle game, and I tell you that you need to match all the colors in a certain pattern. But in reality, you need to match the shapes instead.

*So, you're saying that you'll intentionally mislead me?
->Guide3

== Guide3 == 

Not intentionally, per se. I just want to keep things interesting. Plus, it's all part of the challenge.

*Okay, but how am I supposed to trust you when you've already admitted to being untrustworthy?
->Guide4

== Guide4 == 

Ah, but that's the fun part! You can't trust me, but you also can't win without me. So, you'll have to use your intuition and wit to navigate through the game.

*Alright, I guess I'll give it a shot. But can you at least promise me that the game is fair?
->Guide5

== Guide5 == 
Of course, the game is fair! 
~ End = true

*I like a challenge! Let's do this!
~Heresy -= 1
->DONE

*Is that even true?
~Heresy += 1
->DONE

*I don't know... this seems a bit unfair.
~Heresy += 1
->DONE

*Well, that's not very reassuring, but I'm still willing to play.
~Heresy -= 1
->DONE

*I'm not interested in playing a game where I can't trust the guide.
~Heresy += 1
->DONE