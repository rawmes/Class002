VAR isHostile = true
->main

===main===
A massive battle ship appears. There seems to be something on the comm channel.

 * <scan> I better check it out. 
 
    ->Starfleet420
 * <ignore> Hmm.. this doesnt look interenting. we'll ignore it.
 
    ->DONE


===Starfleet420===

Hey you. Get off my sector this instant.
    * <Inquire> Who are you?
    
        I am the honorable Captain Underpants, incharge of this here vessel and the entire sector 232 in which you and i are currently adrift.
            * * <Let me pass>I need to pass this sector to reach the planet of Humans. They require the medical kit that i am currently tranporting.
                
                ->sft001
            
            * * <Enough of this> Lets dance.
                
            ->DONE
            
    *No
        ->DONE

===sft001===
How do i know you speak the truth and not lies?
    *<Show Proof> Here i have sent you a copy of the transport slip for medical goods.
        Hmm this looks legitimate. Please Stand-by while I verify.
            ** <Positive> Aye aye capn.
                Alright. It seems to be in order. Please hurry and let me know if i can help you by providing a few vessel on my command as my apologies.
                    ***<Thank you> That will not be necessary. But Thank you for the offer.
                        ->endingStuff
                        ~isHostile = false
                    ***<...> ...
                        ->endingStuff
                        
            ** <Hell nah>Sorry capn but there are lives at stakes and it cant wait.
            -> DONE
    *<Enough of this> Lets dance.
    ->DONE
===endingStuff===
Ok.
->END   
    