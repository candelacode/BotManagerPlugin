# Steam familiedeling

ASF støtter Steam Family Sharing - de gamle og de nye systemene. For å forstå hvordan ASF virker med, du bør først lese hvordan **[Steam Family deler](https://store.steampowered.com/promotion/familysharing)**, som er tilgjengelig i Steam butikken. I tillegg til det, sjekk **[at nyheten](https://store.steampowered.com/news/app/593110/view/4149575031735702628)** for kommende nye Steam Family Sharing system, som ASF også er kompatibel med.

---

## ASF

Støtten til Steam Family Sharing feature i ASF er åpen, noe som betyr at det ikke introduserer noen nye bot/prosess konfigurasjonsegenskaper - det fungerer ut av boksen som en ekstra innebygd funksjonalitet.

ASF inneholder hensiktsmessig logikk for å være oppmerksom på at biblioteket låses av familiedelingsbrukere, derfor vil det ikke "sparke" dem ut av økten på grunn av oppstart av et spill. ASF vil fungere nøyaktig som med primærkontoen som holder låsen, derfor hvis den låsen holdes enten av dampklienten din, eller av en av dine familiedelingsbrukere vil ikke ASF forsøke å dyrke, i stedet vil den vente til låsen skal frigjøres. Dette er for det meste knyttet til det gamle systemet - det nye systemet lar familiedeldelingen din til å spille spill med andre enn de som ASF er under landbruk nå.

I tillegg til over, etter innlogging vil ASF få tilgang til dine familiedelingssystemer (gammel og ny), fra hvilke de vil trekke ut brukere (Steam-ID-er) som kan bruke biblioteket ditt. Brukere får `FamilySharing` tillatelse til å bruke **[kommandoer](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, spesielt la dem bruke `pause~` kommando på bot konto som deler spill med dem, som gjør det mulig å sette på automatisk kortdrift-modul i pause for å kunne dele et spill - også dette gjelder for det gamle systemet, men kan fortsatt bli tatt i bruk med det nye systemet i tilfelle ASF er jordbruksspill som brukerne dine vil spille.

Kobler sammen begge funksjonene beskrevet ovenfor tillater vennene dine til `pause~` din kortdrivelsesprosess, start et spill, spill så lenge de ønsker og så etter at de er ferdig med spilling, vil oppgavelappenes jordbruksprosess automatisk gjenopptas av ASF. Selvfølgelig er utstedelse av `pause~` ikke nødvendig hvis ASF for tiden ikke har noe aktivt liv, fordi vennene dine kan starte spillet med en gang, og logikk beskrevet over sikrer at de ikke blir sparket ut av økten.

---

## Begrensninger

Steam nettverk elsker å mislede ASF ved å sende falske statusoppdateringer, noe som kan føre til at ASF tror det er fint å gjenoppta prosessen, og at man da sparker vennen din for kort tid. This is exactly the same issue as the one already explained by us in **[this FAQ entry](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. We recommend exactly the same solutions, mainly promoting your friends to `Operator` permission (or above) and telling them to make use of `pause` and `resume` commands.