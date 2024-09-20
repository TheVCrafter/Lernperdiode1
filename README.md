# Lern-Periode 1

23.08.2024-20.09.2024

## Grob-Planung
Ich möchte mein Programmieren verbessern. Dazu habe ich mir zum Ziel gesetzt ein Hangman in C# zu programmieren.
Der Code soll ein zufälliges Deutsches Wort wählen, welches man anschliessend erraten muss. Wenn man einen Buchstaben errät wird er im Wort 
angezeigt. Falls man einen Falschen Buchstaben rät, Wird der Hangman um ein Strich erweitert. Wenn man das Wort erraten wird bevor der Hangman vollständig ist,
gewinnt man das Spiel und die Konsole wird geschlosse. Falls der Hangman vervollständigt wird verliert man das Spiel und die Konsole wird geschlossen

## 30.08.2024
- [x] Weitere Planung des Projekts (PAP-Designer)
- [x] Beginnen mit Programmieren, das jeder Buchstaben eines Wortes(zunächst nur eins) als _ anzeigt wird und beim Erraten eines Buchstabens des Wortes wieder als Buchstaben.
- [x] "
- [x] "

Heute habe ich eine .Txt-Datei mit allen deutschen Wörtern heruntergeladen, und anschliessend mein Programm dazu gebracht, ein Wort aus der Liste auszuwählen
und anschliessend in form von Unterstrichen auszugeben. Ausserdem kann man inzwischen Buchstaben raten und die Unterstriche werden durch die Erratenen Buchstaben ersetzt.
Ein Problem ist noch, das dass Programm zwischen Gross- und Kleinbuchstaben unterscheidet, ein richtiger Buchstabe also nicht erkannt wird wenn er im Lösungswort gross geschrieben ist,
aber in der Eingabe klein.

## 06.09.2024
- [x] Versuchen das Programm dazu zu bringen nicht zwischen Gross- und Kleinbuchstaben zu unterscheiden
- [x] Die verschiedenen Phasen des Hangmans designen
- [x] Die Phasen in den Code einbauen
- [x] Eventuell weitere Sachen einbauen (z.B. eine Restart-/Beenden-Option innerhalb der Konsole beim Ende des Spiels)

Heute habe ich es Geschafft, dass das Programm bei der Eingabe eines Buchstabens nicht mehr zwischen Gross und Kleinschreibung unterscheidet. Ausserdem habe ich mithilfe von Ascii Art
einen Hangman erstellt und diesen anschliessend in mein Spiel eingebaut. Auch die Restart/ Beenden option am Ende des Spiels konnte ich fertigstellen. Danach habe ich noch eine Start 
funktion eingebaut und mit Hilfe von Ascii Art das Spiel besser Designt. Ich habe auch noch programmiert, dass das zu erratene Wort im Game Over Menü angezeigt wird. 
Das Spiel ist eigentlich so gut wie fertig, trotzdem möchte ich in der Nächsten Stunde noch ein paar zusätzliche Sachen einbauen. Ich möchte zum Beispiel versuchen, auch Ton in das Spiel 
einzufügen und ausserdem das Design noch verbessern.

## 13.9.2024
- [x] Ton in das Spiel einfügen
- [x] Design verbessern
- [x] eventuell auch noch weitere Funktionen einbauen
- [ ] Nach neuer Projektidee suchen

Zu beginn hab ich heute recherchiert wie genau man töne mit der Konsole ausgeben kann und bin schnell auf die SoundPlayer funktion gestossen. Anschliessend habe ich im internet nach passenden 
Tönen für mein Spiel gesucht. Ich wollte für das Spiel nur 8-Bit-Sounds verwenden. Ich brauchte eine Titelmusik, einen Ton welcher beim Start des Spieles abgspielt wird, einen Ton für korrekte 
Antworten, einen für falsche Antworten, einen Ton welcher abgespielt wird wenn man das Wort errät und schliesslich noch einen Ton welcher abgespielt wird wenn der Hangman vervollständigt wird. 
Auf www.pixabay.com wurde ich schliesslich fündig und konnte die Sounds kostenlos herunterladen. Anschliessend musste ich die Downloads vom MP3-Format ins WAV-Format konvertieren. 
Dies habe ich Online mit www.cloudconvert.com gemacht. Dann habe ich die WAV-Dateien in den Debug Folder des Projektes verschoben und anschliessend im Code eingebaut. Dabei habe ich gemerkt, 
dass die Konsole nur einen Sound zugleich abspielen kann, aber das war zum Glück nicht weiter tragisch. Als nächstes habe ich das Farbdesign des Spiels angepasst. Dies machte ich mit der 
Console.Foregroundcolor-Methode. Nachdem ich so das Spiel relativ schön gestalten konnte, habe ich die Datei mit den deutschen Wörtern auch noch in den Debug-Folder verschoben und den Code 
entsprechend umgebaut. Leider bin ich noch nicht dazu gekommen, nach einer neuen Projektidee zu suchen.

## 20.9.2024
- [ ] Die Funktion hinzufügen, dass bereits geratene Buchstaben nicht nochmals geraten werden können
- [ ] Jetztiges Projekt endgültig abschliessen
- [ ] Neue Projektidee suchen

