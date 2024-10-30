import { MyEnvironment } from './my-environment';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Macro',
  },
  oAuthConfig: {
    issuer: 'http://localhost:8080/realms/master',
    redirectUri: baseUrl,
    clientId: 'Web',
    responseType: 'code',
    scope: 'offline_access openid profile email phone roles AdministrationService IdentityService', 
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'https://localhost:7500',
      rootNamespace: 'Macro',
    }
  },
  mediaServerUrl:'https://localhost:7500'
} as MyEnvironment;


