# Ruota pazza

## DB

- donation: ID, email
- winners: ID, email, winning_date, amount_of_donations
- prize: name, image, threshold

## Dashboard

- Autenticazione
- Lettura
- Scrittura

## Arduino/ESP32

- Zibo

## BE donazioni/estrazione

### Estrazione

- Donazione random da DB
- E-mail al vincitore
- E-mail a admin
- Svuotamento tabella donazione

### Donazione

- Ricezione web-hook PayPal
- Scarto donazioni con amount sbagliata
- Salvataggio donazione
- Messaggio a Arduino/ESP32

## BE per Arduino/ESP32

- Scelta tecnologia di comunicazione Rust-C#
- Zibo

## TODO

- Paypal: check web-hooks API
- Milestone 1: BE che logga in console quando PayPal riceve una donazione
- BE dashboard
- Milestone 2: BE che logga quando ha ricevuto abbastanza soldi per estrarre
- Estrazione
- Milestone 3: BE che manda e-mail con vincitore ad admin
- FE dashboard
- Milestone 4: login + salvataggio premio
- BE Arduino/ESP32
- Milestone 5: BE che manda messaggio "WebSocket" quando riceve una donazione
- Arduino/ESP32
