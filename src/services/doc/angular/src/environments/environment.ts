 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'http://localhost:8080/realms/master',
  redirectUri: baseUrl,
  clientId: 'Web',
  responseType: 'code',
  scope: 'IdentityService AdministrationService',
  requireHttps: false,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'DocService',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:7400',
      rootNamespace: 'Macro',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
