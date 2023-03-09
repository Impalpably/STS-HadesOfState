INCLUDE Globals.ink

VAR End = false

Welcome to the first level of hell Limbo. I am Marcus Aurelius and I am your very insightful guide. 

*So what are your insights?
->Aurelius

== Aurelius ==

{~When you be a stability of their sentiments and stand firm against the mistake; or defer the tenderest and commotions to those to be more suitable?. Upon every accident, keep in it. | And still remember, that the least appearance of justice, temperance, good-nature,and every virtue.}

*Yea, try again? 
~Corruption += 1
->Aurelius2

== Aurelius2 == 

{~You may make the dancer, since the fountain of urgent affairs, to decline or defer the countenance, in a good use of body, free from loose inconstant motion. | To approve and graceful air, so, it should study also a good use of souls they ought, in it.| Be you intent upon this, how to avoid censuring others, and yet without great maxims necessary for you, for, what can be observed without noise, to yourself, and are changed.}

*No I don't get it, try again.
~Corruption += 1
->Aurelius3

== Aurelius3 == 

{~Do you will neither accuse such courteous insinuation. | You may make the mistake; or social. | Leave these unnatural changes and applaud others, or destroy it; nor does it make an excellent use of men they ought, in view those we account nobly born, have somehow less natural affection.}


*Right
~Corruption += 1
->Finish


== Finish == 

I should tell you. Every conversation you have, every choice you make and every reply will cost you your place in hell, or if you're very good, still hell. So be careful what you say.

And my final parting wisdome. You may make an excellent use of life.

~ End = true

*Ok
->DONE