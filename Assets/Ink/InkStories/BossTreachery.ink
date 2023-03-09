INCLUDE Globals.ink

VAR End = false

{~Treachery, it is a fearsome place. But remember, you are not here to be punished. You are here to find redemption. | Welcome, mortal. You have come to the domain of treachery, where those who have betrayed their closest companions and benefactors are punished. }

*This is it, the final level of hell. The place where the ultimate level. 
~Treachery += 1
->Treachery1

*But what about those who have betrayed themselves? What happens to them?
~Treachery += 1
->Treachery1


== Treachery1 == 

Ha! Such foolishness. Those who betray themselves are the lowest of the low. They belong here, with us, in eternal suffering.

*But have I betrayed myself? Have I been untrue to my own beliefs and values?
~Treachery += 1
->Treachery2


== Treachery2 == 

That is for you to decide. 

*Noo, fuck that, I want heaven
~Treachery += 1
->Treachery3

*I deserve it
~Treachery += 1
->Treachery3

*So, if I say I deserve, thats a betrayal right, but if I say I don't deserve it, thats pretty arrogant, uhh...
~Treachery += 1
->Treachery3

== Treachery3

{~Ha! You think you can redeem yourself after all that you have done? | I believe that you have the strength and courage to face your own demon} 

Time to decide, where do you belong? 

*Heaven
~Treachery += 1
->Ending1

*Hell
~Treachery += 1
->Ending2

*Maybe like limbo?
~Treachery += 1
->Ending4

Somewhere in the middle!
~Treachery += 1
->Ending4

== Ending1 == 

The player emerges from the final level of hell with a newfound sense of purpose and self-awareness, ready to face whatever challenges may come their way.

*You start at the beginning again.
->DONE

== Ending2 == 

The player is consumed by the demons of treachery, and is doomed to suffer in the final level of hell for all eternity.

*Ouchie
->DONE

== Ending4 ==
You wander aimlessly through the final level of hell in Dante's Inferno, dedicated to treachery, where those who have committed the ultimate betrayal are punished. But their punishments aren't yours, you're a spectator. You watch as souls are subjected to varying degrees of torment, ranging from immersion in ice to ceaseless rain of fire and brimstone. At the center of the final level, Satan is trapped in a frozen lake, constantly flapping his wings and creating a freezing wind that keeps him and the other souls trapped in their icy tombs, representing the ultimate isolation and despair of those who have committed this sin.

Eventually, you realize that redemption is something that can only come from within, and that the true journey was the one you took to get here.
*You're still stuck in hell though
->DONE