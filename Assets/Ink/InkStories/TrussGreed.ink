INCLUDE Globals.ink

VAR End = false

Hello, {~There is a quitter, not a prime minister, so humiliated. | There is a quitter, a slime-soaked baddie. In much the time she was Prime Minister.}

*Hi, I'm a fan of trickle down economics actually
~Greed += 1
->Truss

*You were the best primeminister, for all 5 seconds
~Greed += 1
->Truss

*Liz, what do you think is so wrong with politics?
~Greed -= 1
->Truss

== Truss == 

{~Never seen one who deserved it, gremlins are everywhere. | The process of electing Liz Truss is a temptation to multiply and exert further control. | There is actually a temptation to the smartphone – to multiply and bureaucracy to be Prime Minister.}

*Rich people are always the real victims
~Greed += 1
->Truss2

*Yes, so how come you quit so fast? 
->Truss2

*I guess you tried your best, even if that was er...
~Greed -= 1
->Truss2

== Truss2 == 

{~Because British people love change. Never seen one of the latest gadgets – to multiply and exert further control. | Because British people love change.From the microwave meal to multiply and exert further control.}

~ End = true

*That clears that up then.
->DONE