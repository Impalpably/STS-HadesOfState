INCLUDE Globals.ink

VAR End = false

And now you find yourself in anger.

{~There is the stench of purpose. | Power is success?}

*So why are you in the anger circle? 
->ThatcherCircle

== ThatcherCircle == 

I always cheer up immensely if they attack one personally, it was because I love debate. 

*It's becoming harder to stay morale.
~Wrath += 1
->Thatcher

== Thatcher ==

{~It may be the eggs. | I think, well, if they attack one personally, it is not enough, that it is not their job. |The spirit of having a flair for the Thames they have to do what you know, it is like being a mixture of appeasement in the cock that you aren't.}

*I think, it's best to be calm
~Wrath += 1

->Thatcher2

== Thatcher2 ==

{~The spirit of appeasement in the air. | I think it is a single political argument left. | Disciplining yourself to smell the cock that lays the hen, that is a funny old world. | It may be the high road to smell the hen that crows, but is it success? | There is the cock that lays the hen that lays the cock that crows | I always cheer up immensely if they attack one personally, it was because I love debate.}

*Insightful
~Wrath += 1

->Finish

== Finish == 

{~You may make an excellent use of life. | Power is right and personal satisfaction}

~ End = true

*Ok
->DONE