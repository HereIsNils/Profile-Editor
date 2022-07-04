# Profil Editor

## Features ToDo

- [ ]  Anzeige für ausgewählten coolant mode fixen
- [ ]  App Level soll man umbennen können
- [ ]  Dateiname der geöffneten XML Datei anzeigen
- [ ]  evtl. Dialog für Info schöner machen
- [ ]  Neue XML Datei Version enthält definierte Namespaces (xmlns) → Aktuelle Model Klasse kann diese Namespaces nicht verwerten, Objekt bleibt null
    
    ```xml
    <!-- Beispiel -->
    <AppLevelName>
    		<!--AppLevel Generic1-->
    		<AppLevel xmlns="AppLevelName">1</AppLevel>
    		<!-- string - 1-25 length -->
    		<Value>Exkavation</Value>
    </AppLevelName>
    ```
    
- [ ]  evtl. mehr Feedback von der Anwendung (Messagebox wenn gespeichert wurde oder die Startup Datei festgelegt wurde)