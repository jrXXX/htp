// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  mock: false,
  production: false,
  docker: false,
  backendUrl: 'http://localhost:8080',
  ownUrl: 'http://localhost:4200',
  signOn: {
    authority: 'https://login.microsoftonline.com/45a8141c-94c3-4fde-9cf3-0cfcc10ad529',
    clientId: '9f9965aa-840d-4c88-8121-eac081ee2dd8',
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
