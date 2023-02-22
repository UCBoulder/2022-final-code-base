# CUTEE_CLUB

CU for Technology in Extreme Environments (CUTEE) is developing a software that will integrate the HoloLens 2 in a user interface for the 2022 NASA SUITS Challenge. The goal of our design is to aid astronauts in navigation, search and rescue, and geological research on the lunar surface. The user will be equipped with an electromyography (EMG) sensor that will allow the astronauts to communicate with the interface hands-free. Voice commands will be utilized to access various tools of the user interface, such as viewing vitals and activating the EMG sensor. The user will be able to switch between different modes in the interface to view navigational and geological guidance and  EVA tasks equipped with an alert system that will notify the user in emergency situations and/or lunar search and rescue. 

---
### Set-up instructions
---
Server:
---
The server is run in Node.js. Download Node from: https://nodejs.org/en/download/

To run the server, navigate to ```cd TelemetryServer22``` and run ```node --version``` to verify that Node is installed.

Then, to start the server, run the commands:

```
npm install
npm update
node bootstrap.js
```
The client should be running.

---
Client:
---
The server is run in Angular. After installing Node, Angular can be installed via ```npm install -g @angular/cli```

To run the client, navigate to ```cd TelemetryServer22/frontend``` and run ```ng --version``` to verify that Angular is installed.

Then, to start the client, run the commands:

```
npm install
npm update
ng update
ng serve
```
The server should be running. Ensure that the server is running for the client to connect to. There should be feedback from the server that the client has connected.

---
