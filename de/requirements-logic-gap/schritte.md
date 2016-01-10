# Schritte zur Überwindung der Lücke
Die [Requirements-Logic-Gap](README.md) ist groß und weit. Unterschätze sie nie! Der Aufwand, sie zu überwinden, ist im Grunde immer größer, als du zunächst denkst.

Wie kannst du dir es aber einfacher machen? Wie könnten Trittsteine platziert sein, um dir den Weg von den Anforderungen zur [Logik](logik.md) leichter zu machen. Kleine und große Schritte sind ok, einen Spagat oder gar ein Sprung solltest du vermeiden.

Zunächst standen wir auch nur vor dieser Lücke und waren ratlos. Zwar hatten wir sie unzählige Male überwunden... doch uns war nicht wirklich, wirklich klar, wie wir das geschafft hatten. Es war mehr Durchwurschteln als präzise Arbeit entlang eines klaren Weges, mehr Auto Scooter als Zugfahrt.

Dabei war zumindest der grobe Weg schon jahrzehntelang ausgeschildert. Er besteht aus drei Abschnitten: Analyse, Entwurf und Implementation.

![](../../resources/images/requirements-logic-gap/gapphases.png)

Das ist nicht neu für dich, oder? Wir kannten diese Abschnitte auch. Im Grunde kann sie sogar niemand umgehen. Aber man kann sich ihrer auf dem Weg zur Logik mehr oder weniger bewusst sein. Man kann sie mit _trial and error_ durchstolpern oder systematisch durchschreiten.

* Alles beginnt mit der Problemanalyse. Am Anfang steht das Verstehen. Wer die Aufgabe nicht versteht, kann keine Lösung entwickeln. Das sollte auf der Hand liegen. Und irgendwie bemüht sich jeder Entwickler auch darum.
* Wenn man das Problem verstanden hat, dann kann man sich überlegen, die eine Lösung _aussehen_ sollte. Man macht sich einen Plan der Lösung, aber baut sie noch nicht. Das ist ein Schritt, über den viel diskutiert wird (Stichworte Architektur, Entwurf), der jedoch vielen Entwickler sehr schwer fällt. Hier ist die Unsicherheit nach unserer Beobachtung sehr groß. Immer wieder wird gesprungen, denn geschritten.
* Schließlich setzt man den Plan um in Code. Das ist der Schritt, den die meisten Entwickler am liebsten tun. Oder wie geht es dir? Hier kommen Programmiersprachen und andere Technologien endlich zum Einsatz. Das ist 'was für echte Programmierer. Darüber kann man sich in der Community die Köpfe heiß reden.

So weit, so einfach. Vielleicht fühlst du dich ertappt, diese Abschnitte im Programmieralltag nicht deutlich von einander zu trennen. Doch irgendwie kanntest du sie schon.

Dann lass uns weitergehen und überlegen: Was sind die Ergebnisse der Arbeit in den Abschnitten?

## Phasenübergänge
Die Wegabschnitte von den Anforderungen bis zur Logik kannst du auch als Phasen eines Transformationsprozesses ansehen.

Der Gesamtprozess transformiert Anforderungen in Logik. Aber in was werden Anforderungen in der ersten Phase, der Anforderungsanalyse transformiert? Und was ist das Ergebnis des Entwurfs? Dass die letzte Phase Logik als Output generiert, ist klar.

![](../../resources/images/requirements-logic-gap/unknownphaseresults.png)

### Die Entwurf:Implementation-Schnittstelle
Fangen wir von unten/hinten an. Die Implementation ist dir bestimmt am vertrautesten. Wie könnte der Input aussehen, um die Implementation möglichst einfach zu machen?

Die Implementation setzt natürlich Anforderungen um. Es muss also ein gewisser Scope anliegen, für den [Logik](logik.md) zu finden ist. Der Entwurf liefert ja nicht die Logik selbst, sondern nur einen Rahmen, in den nun die Implementation Logik gießen soll.

Wie du im [Experiment](README.md) selbst bemerkt hast, ist es schon für einen kleinen Anforderungsscope nicht ganz leicht, die Logik zu bestimmen. Das bedeutet: Der Entwurf muss der Implementation Scope in sehr kleinen Happen zur Transformation in Logik liefern.

Aus unserer Sicht schießt sich die Softwareentwicklung immer wieder selbst in den Fuß, indem sie versucht, für zu großen Scope zur Logik zu springen. Das ist auch kein Wunder, wenn der Fokus ständig auf der Implementationsphase liegt.

Deshalb wollen wir es ganz klar machen: Der Implementation muss umzusetzender Scope in sehr kleinen Happen geliefert werden. Im Grunde muss die Logik sogar auf der Hand liegen für den jeweiligen Scope.

Und wie liefert der Entwurf diese Scope-Happen ab? In Form von Funktionssignaturen.

Der Output des Lösungsentwurfs ist also eine Menge von Funktionsdefinitionen. Und zwar Funktionen mit sehr überschauberer Verantwortlichkeit.


 

### Die Analyse:Entwurf-Schnittstelle





