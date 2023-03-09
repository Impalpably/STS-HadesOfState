INCLUDE Globals.ink

VAR End = false

Welcome, young lady, to the Maleboge. 

*Hello, old sir, and what did you do?
~Fraud -= 1
->Berlusconi

*Nice to meet you, you {sick|bad} man. I can't imagine what you are doing here.
~ Fraud += 1
->Berlusconi

*What are you doing here?
~ Fraud -= 1
->Berlusconi

== Berlusconi ==

{ ~I didn't pay her to be very good at it. | It's just a bunch of corruption and bribery (laughs) Please, my friend, I'm the game. | I'm always ready to avoid taxes. | *As a successful businessman, you should know that allegations of corruption and embezzlement can ruin your reputation and credibility. It's better to address these allegations head-on and clear your name instead of denying or ignoring them."}

*I'm always ready to avoid taxes.
~Fraud += 1
->Berlusconi2

*"I don't think that's a good idea. Tax evasion is illegal, and it can have severe consequences.
~Fraud -= 1
->Berlusconi2

*What about the allegations of corruption and embezzlement?
~Fraud -= 1

->Berlusconi2


->Berlusconi2

== Berlusconi2 == 

{~I mean, I thought she was older. admitting to bring down a beautiful girl I mean, I just a successful businessman | "Oh, come on, it was just a bit. paying an underage prostitute for sex, I just say I mean, I paid her out a matter of jealous bureaucrats trying to talk about the allegations of tax fraud and wave. }
 

* As a successful businessman, you should know better than to engage in such actions. 
~Fraud -= 1
->Finish

*Perhaps it's better to be upfront and honest about your income.
~Fraud -= 1
->Finish

 *That's a risky move, my friend.
 ~Fraud += 1
->Finish

*Sounds like you were just having fun and being frugal
~Fraud += 1
->Finish


== Finish ==

Bye bye, young lady, watch out for the Malebranche!

~ End = true

*Well that was interesting
->DONE