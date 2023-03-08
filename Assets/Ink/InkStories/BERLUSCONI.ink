INCLUDE Globals.ink

VAR End = false

Welcome, young lady, to the Maleboge. 


*Nice to meet you, you {sick|bad} fuck. I can't imagine what you are doing here.
~ Wrath += 1
->Berlusconi

*What are you doing here?
~ Wrath -= 1
->Berlusconi

== Berlusconi ==

{ ~I didn't pay her to be very good at it. | It's just a bunch of corruption and bribery (laughs) Please, my friend, I'm the game. | I'm always ready to avoid taxes. | *As a successful businessman, you should know that allegations of corruption and embezzlement can ruin your reputation and credibility. It's better to address these allegations head-on and clear your name instead of denying or ignoring them."}

*I'm always ready to avoid taxes.
->Berlusconi2

*"I don't think that's a good idea. Tax evasion is illegal, and it can have severe consequences. It's always better to play fair and square, even in a video game."
->Berlusconi2

*What about the allegations of corruption and embezzlement?
->Berlusconi2


->Berlusconi2

== Berlusconi2 == 

{I mean, I thought she was older. admitting to bring down a beautiful girl I mean, I just a successful businessman | "Oh, come on, it was just a bit. paying an underage prostitute for sex, I just say I mean, I paid her out a matter of jealous bureaucrats trying to talk about the allegations of tax fraud and wave. }
 
 *"That's not acceptable, even in a video game. Paying an underage prostitute for sex is illegal and unethical. We should always promote ethical behavior and avoid promoting illegal or harmful actions, even in a virtual world.
 
*Regardless of your intentions, paying an underage prostitute is illegal and immoral. As a successful businessman, you should know better than to engage in such actions. Let's focus on playing the game ethically and promoting positive values."

 *That's a risky move, my friend. Tax evasion can land you in serious trouble. Perhaps it's better to be upfront and honest about your income and pay the necessary taxes to avoid legal consequences.
->Finish



== Finish ==

~ End = true
*Well that was enlightning
->DONE