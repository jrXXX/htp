# Introduction 
This is the frontend application of the AKROS Holiday Tech Playground project. See https://wiki.akros.ch/display/TO/AKROS+Holiday+Tech+Playground for documentation. 

# Getting Started
1. Install the latest version of node.js from https://nodejs.org/en/.
1. Check installation by running `npm version`.
1. At the root of the project, run `npm install`.

To start the application, run `npm start`. Navigate to `http://localhost:4200/`. The app will use the backend deployed at http://htp-portal-backend.azurewebsites.net/. It will automatically reload if you change any of the source files. Other available scripts can be found in the file package.json.

# Further information

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 10.2.0.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Connect to local server
In the root directory of the backend project, run `mvnw spring-boot:run` or `mvnw org.springframework.boot:spring-boot-maven-plugin:run` to start the server at http://localhost:8080.

In the frontend project, replace the backend URL in package.json and src/app/app.module.ts.

In order for the frontend to query the server, you also have to [allow for cross origin requests](https://daveceddia.com/access-control-allow-origin-cors-errors-in-angular/). It is easiest to install a browser extension (like CORS Everywhere on Firefox) in order to do this. Alternatively, you can you can add the required header for the server endpoint you are requesting like so:
`return ResponseEntity.ok(body);`
becomes
`return ResponseEntity.ok().header("Access-Control-Allow-Origin", "http://localhost:4200").body(body);`.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page...
