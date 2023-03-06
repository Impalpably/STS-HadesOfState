INCLUDE Globals.ink

VAR End = false

You are in hell

*Hello
->Welcome

*Shit
->Welcome

== Welcome ==

*OH
~ Wrath += 1
->Finish

*YAY
~ Lust += 1
->Finish

*NOO
~ Corruption += 1
->Finish

== Finish == 

~ End = true

*Ok
->DONE