# Requirements-Logic-Gap
Warum fällt es in vielen Projekten so schwer, flüssig und nachhaltig zu arbeiten? Das beobachten wir sogar dort, wo ein Agiles Vorgehensmodell (Prozess) implementiert wurde.

Unsere Hypothese dazu: Softwareentwicklung wird zu wenig differenziert betrachtet. Zu viel Kunst, zu wenig Systematik. Die Tätigkeit "Entwicklung" wird im Grunde als Monolith empfunden: Man lernt etwas Paradigma (z.B. Objektorientierung), man lernt etwas Programmiersprache (z.B. C#, Java, Ruby & Co), man lernt etwas Technologie (z.B. WPF, MongoDB, RabbitMQ). Und dann "macht man halt". Dann beginnt das große Wurschteln.

Das Ergebnis dieser Herangehensweise ist zu ihr kongruent: es ist ein Gewurschtel, ein Monolith. Spaghetticode war vorgestern; heute sagt man vornehmer _legacy code_. Gemeint ist aber dasselbe: Code, der kaum durchschaubar ist und jeden Tag schwerer verändert werden kann.

Das ist natürlich nicht nachhaltig. So lässt sich auch nicht dauerhaft flüssig wertvoller Code herstellen.

2009 haben wir deshalb die Clean Code Developer Initiative ([clean-code-developer.de](http://clean-code-developer.de)) gegründet. Dort findest du 42 Prinzipien und Praktiken für sauberen Code, d.h. solchen, der sich länger flüssig produzieren lässt. Wir nennen das Evolvierbarkeit.

Diese Sammlung war damals eine gute Idee. Sie hat vielen Entwicklern geholfen. Doch schon bald haben wir bemerkt, dass es damit nicht genug ist. Es fehlte etwas. Das war ein _big picture_, ein Zusammenhang, ein Rahmenwerk.

Und zwar fehlte ein Rahmenwerk, das ganz am Anfang beginnt, nämlich bei der Frage: Was soll das mit der Softwareentwicklung überhaupt? Was tun wir als Programmierer eigentlich, wenn wir Software entwickeln?

Solange diese fundamentale Frage nicht ganz einfach beantwortet ist, können wir nämlich nicht wirklich beurteilen, inwiefern irgendeine Technik oder ein Prinzip usw. dazu überhaupt beiträgt.

## Von Anforderungen zur Logik
Also: Was soll das Ganze?

Es ist so selbstverständlich, dass es kaum der Erwähnung wert ist: Softwareentwicklung soll Anforderungen in Code verwandeln. Sie beginnt bei der natürlichsprachlichen Beschreibung von Funktionalitäten und Effizienzen; sie endet mit der Ablieferung von programmiersprachlichem Code, der diese Anforderungen erfüllt.

Dass es am Ende um ausführbaren Code geht, also nicht Code in einer Hochsprache wie C# oder Go ausgeliefert wird, ist eine Feinheit, die dem grundlegenden Zweck nicht widerspricht.

![](../../resources/images/requirements-logic-gap/req2code.png)

Der ausführbare Code ist das angestrebte Resultat, weil der in der Ausführung Verhalten gegenüber den Anwendern erzeugt, das ihnen (hoffentlich) nützt.

Anwender interagieren mit dem Code: Sie geben Daten ein, lösen Funktionalität aus, erhalten Daten als Ergebnis. Software verhält sich damit, weil sie reagiert. Die Reaktion besteht im Output. Der kann einfach nur am Bildschirm dargestellt werden oder zeigt sich in Zustandsveränderungen von Geräten.

Bis hierher klingt das selbstverständlich für dich, oder? Was sonst sollte der Zweck von Softwareentwicklung sein?

Aber lass uns nicht beim Selbstverständlichen stehenbleiben. Lass uns genauer hinschauen. Denn hier steckt der Teufel im Detail. Und wenn wir ihn dort aufgespürt haben, wirst du verstehen, warum Softwareentwicklung nicht monolithisch sein und nicht als künstlerische Veranstaltung gedacht werden darf.

Einerseits lässt sich genauer auf Anforderungen schauen. Was gibt es eigentlich für Anforderungen? Darüber lässt sich trefflich einige Zeit lang nachdenken und diskutieren. Lassen wir es einstweilen pauschal bei funktionalen und nicht-funktionalen Anforderungen. Software soll etwas tun (z.B. rechnen) und das soll sie in gewisser Weise tun (z.B. schnell).

Andererseits lässt sich genauer auf Code schauen. Was gibt es eigentlich für Code? Oder noch genauer: Ist eigentlich der gesamte Code, den du als Programmierer schreibst, dafür verantwortlich, Verhalten herzustellen?

Denk an all die Zeilen, die du täglich schreibst. Welche davon tragen dazu bei, dass Funktionalität oder Effizienz nach Geschmack des Kunden entsteht?

Die Antwort ist einfach: nur Zeilen, die [Logik](logik.md) enthalten, stellen Verhalten her.

Was Logik ist, erklären wir dir besser [auf einer eigenen Seite](logik.md). Für den hiesigen Überblick ist im Moment nur wichtig, dass das eben lediglich ein Teil des gesamten Codes ist. Und nur genau dieser Teil des Code interessiert den Kunden. Nur dafür ist er (zunächst) bereit, Geld auszugeben.

Die Transformationsaufgabe der Programmierung können wir damit genauer formulieren:

///transformation anforderungen -> programmieren -> logik

Sie soll den Input Anforderungen (requirements) in den Output Logik (logic) überführen. Nicht mehr, nicht weniger.

## Die Lücke


